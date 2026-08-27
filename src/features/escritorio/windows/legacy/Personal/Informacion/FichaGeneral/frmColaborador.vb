Imports System.ServiceModel
Imports System.IO
Public Class frmColaborador

    '=========================== Servicios ====================================
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCapacitacionService As New CapacitacionService.CapacitacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '====================== Declaración de Variables ==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable 

    '-------------- Ficha General -------------
    Public IdPersona As Integer
    Public ApeNom As String
    Public CodUbigeo As String                    'Código de Ubigeo
    Private CodEmp As String
    Private dtNacionalidad As DataTable
    Private dtTipoDoc As DataTable
    Private dtEstCivil As DataTable
    Private dtTipoVia As DataTable
    Private dtTipoZona As DataTable
    Private dtUnidades As DataTable
    Private dtAreas As DataTable
    Private dtClase As DataTable
    Private dtSituacionEspecial As DataTable
    Private dtCargo As DataTable
    Private dtCentroCosto As DataTable

    '------------------ Familiares -----------------
    Private IdFamilia As Integer                 'Id de Familia 
    Private dtDatosFamiliares As DataTable
    Private edicionFamiliares As Boolean = False
    Private state_familiar As Boolean
    Public CodUbigeoFam As String                    'Código de Ubigeo
    Private dtTipoBajaHabiente As DataTable
    Private dtTipoDocPat As DataTable
    Private dtTipoDocFam As DataTable
    Private dtTipoViaFam As DataTable
    Private dtTipoVinculo As DataTable
    Private dtTipoZonaFam As DataTable

    '---------- Estudios Realizados ---------
    Private IdEstudio As Integer                'Id de Estudio
    Private dtDatosEstudios As DataTable
    Private edicionEstudio As Boolean = False
    Private state_estudio As Boolean
    Private dtNivelEstudio As DataTable

    '------------------- Idioma --------------------
    Private IdIdioma As Integer                  'Id de Idioma
    Private dtDatosIdioma As DataTable
    Private edicionIdioma As Boolean = False
    Private state_idioma As Boolean
    Private dtIdioma As DataTable
    Private dtNivelIdio As DataTable

    '---------------- Informática -----------------
    Private IdInformatica As Integer              'Id de Informatica
    Private dtDatosInformatica As DataTable
    Private edicionInformatica As Boolean = False
    Private state_informatica As Boolean
    Private dtPrograma As DataTable
    Private dtNivelInfo As DataTable

    '---------------- Exp. Laboral -----------------
    Private IdExperiencia As Integer           'Id de Experiencia Laboral
    Private dtDatosExpLaboral As DataTable
    Private edicionExpLaboral As Boolean = False
    Private state_explaboral As Boolean
    Private dtMonExpLab As DataTable

    '-------------- Capacitaciones ---------------
    'Private IdCapacitacion As Integer         'Id de Capacitación
    'Public IdProveedor As Integer
    'Private dtDatosCapacitaciones As DataTable
    'Private edicionCapacitacion As Boolean = False
    'Private state_capacitacion As Boolean
    'Private dtTipoCapacitacion As DataTable
    'Private dtMonCapacitacion As DataTable

    '--------------CESES---------------
    Private dtCese As DataTable
    Private IdCese As Int64
    Private edicionCese As Boolean = False
    Private state_cese As Boolean

    Private Sub frmColaborador_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPersonaService.Close()
            oCapacitacionService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oCapacitacionService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oCapacitacionService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaVarColaborador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EstillosGrid()
        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
            Desactivar()
            Me.Text = "Colaborador: " + Chr(34) + ApeNom + Chr(34)

            ListarFamiliares()
            DesactivarFamiliar()

            ListarEstudios()
            DesactivarEstudio()

            ListarIdiomas()
            DesactivarIdioma()

            ListarInformaticas()
            DesactivarInformatica()

            ListarExpLaboral()
            DesactivarExpLaboral()

            'ListarCapacitaciones()
            'DesactivarCapacitacion()

            ListarCeses()
            DesactivarCeses()
        Else                          'Nuevo
            Me.Text = "Registrar nuevo Colaborador"
            Activar()
            rbMasculino.Checked = True
            cmbNacionalidad.Value = "9589"
            cmbTipoDoc.Value = "1"
            txtFecIniPlanilla.Value = Today()
            CodEmp = Session.sCodEmp
            txtEmpresa.Text = Session.sDesEmp
        End If
    End Sub

    Private Sub EstillosGrid()
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvFamiliares)
        dgvFamiliares.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvFamiliares.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvEstudios)
        dgvEstudios.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvEstudios.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvIdioma)
        dgvIdioma.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvIdioma.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvInformatica)
        dgvInformatica.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvInformatica.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvExpLaboral)
        dgvExpLaboral.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvExpLaboral.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvCapacitaciones)
        dgvCapacitaciones.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvCapacitaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        estilo.CargaEstiloGrid(dgvCese)
        dgvCese.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvCese.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '/////////////////////////////////////////////////////////////////////// FICHA GENERAL /////////////////////////////////////////////////////////////////////////////////////////

            '==================================== NACIONALIDAD =============================================
            dtNacionalidad = oPersonaService.MostrarNacionalidades.Tables(0)
            cmbNacionalidad.DataSource = dtNacionalidad
            cmbNacionalidad.DropDownList.DataMember = dtNacionalidad.Columns("DesNac").ToString
            cmbNacionalidad.DropDownList.DisplayMember = dtNacionalidad.Columns("DesNac").ToString
            cmbNacionalidad.DropDownList.ValueMember = dtNacionalidad.Columns("CodNac").ToString
            cmbNacionalidad.DropDownList.Columns(0).DataMember = dtNacionalidad.Columns("CodNac").ToString
            cmbNacionalidad.DropDownList.Columns(1).DataMember = dtNacionalidad.Columns("DesNac").ToString
            cmbNacionalidad.SelectedIndex = 0
            dtNacionalidad = Nothing

            '=================================== TIPO DE DOCUMENTO ========================================
            dtTipoDoc = oPersonaService.MostrarTipoDocumento.Tables(0)
            cmbTipoDoc.DataSource = dtTipoDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipoDoc.Columns("CodDoc").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipoDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipoDoc = Nothing

            '====================================== ESTADO CIVIL ===========================================
            dtEstCivil = oPersonaService.MostrarEstadoCivil.Tables(0)
            cmbEstadoCivil.DataSource = dtEstCivil
            cmbEstadoCivil.DropDownList.DataMember = dtEstCivil.Columns("DesEstado").ToString
            cmbEstadoCivil.DropDownList.DisplayMember = dtEstCivil.Columns("DesEstado").ToString
            cmbEstadoCivil.DropDownList.ValueMember = dtEstCivil.Columns("IdEstado").ToString
            cmbEstadoCivil.DropDownList.Columns(0).DataMember = dtEstCivil.Columns("IdEstado").ToString
            cmbEstadoCivil.DropDownList.Columns(1).DataMember = dtEstCivil.Columns("DesEstado").ToString
            cmbEstadoCivil.SelectedIndex = 0
            dtEstCivil = Nothing

            '======================================== TIPO VÍA ==============================================
            dtTipoVia = oPersonaService.MostrarTipoVias.Tables(0)
            dtTipoVia.Rows.InsertAt(getRowTodos(dtTipoVia), 0)
            cmbTipoVia.DataSource = dtTipoVia
            cmbTipoVia.DropDownList.DataMember = dtTipoVia.Columns("AbrVia").ToString
            cmbTipoVia.DropDownList.DisplayMember = dtTipoVia.Columns("AbrVia").ToString
            cmbTipoVia.DropDownList.ValueMember = dtTipoVia.Columns("CodVia").ToString
            cmbTipoVia.DropDownList.Columns(0).DataMember = dtTipoVia.Columns("CodVia").ToString
            cmbTipoVia.DropDownList.Columns(1).DataMember = dtTipoVia.Columns("AbrVia").ToString
            cmbTipoVia.SelectedIndex = 0
            dtTipoVia = Nothing

            '======================================= TIPO ZONA =============================================
            dtTipoZona = oPersonaService.MostrarTipoZonas.Tables(0)
            dtTipoZona.Rows.InsertAt(getRowTodos(dtTipoZona), 0)
            cmbTipoZona.DataSource = dtTipoZona
            cmbTipoZona.DropDownList.DataMember = dtTipoZona.Columns("AbrZona").ToString
            cmbTipoZona.DropDownList.DisplayMember = dtTipoZona.Columns("AbrZona").ToString
            cmbTipoZona.DropDownList.ValueMember = dtTipoZona.Columns("CodZona").ToString
            cmbTipoZona.DropDownList.Columns(0).DataMember = dtTipoZona.Columns("CodZona").ToString
            cmbTipoZona.DropDownList.Columns(1).DataMember = dtTipoZona.Columns("AbrZona").ToString
            cmbTipoZona.SelectedIndex = 0
            dtTipoZona = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

            '==================================== SITUACIÓN ESPECIAL ========================================
            dtSituacionEspecial = oPersonaService.MostrarSituacionEspecial.Tables(0)
            cmbSituacionEspecial.DataSource = dtSituacionEspecial
            cmbSituacionEspecial.DropDownList.DataMember = dtSituacionEspecial.Columns("DesSit").ToString
            cmbSituacionEspecial.DropDownList.DisplayMember = dtSituacionEspecial.Columns("DesSit").ToString
            cmbSituacionEspecial.DropDownList.ValueMember = dtSituacionEspecial.Columns("CodSit").ToString
            cmbSituacionEspecial.DropDownList.Columns(0).DataMember = dtSituacionEspecial.Columns("CodSit").ToString
            cmbSituacionEspecial.DropDownList.Columns(1).DataMember = dtSituacionEspecial.Columns("DesSit").ToString
            cmbSituacionEspecial.SelectedIndex = 0
            dtSituacionEspecial = Nothing

            '======================================== CARGO ===============================================
            dtCargo = oPersonaService.MostrarCargos(Session.sCodEmp, "").Tables(0)
            cmbCargo.DataSource = dtCargo
            cmbCargo.DropDownList.DataMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.DropDownList.DisplayMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.DropDownList.ValueMember = dtCargo.Columns("CodCargo").ToString
            cmbCargo.DropDownList.Columns(0).DataMember = dtCargo.Columns("CodCargo").ToString
            cmbCargo.DropDownList.Columns(1).DataMember = dtCargo.Columns("DesCargo").ToString
            cmbCargo.SelectedIndex = 0
            dtCargo = Nothing

            '//////////////////////////////////////////////////////////////////////// FAMILIARES ///////////////////////////////////////////////////////////////////////////////////////////

            '=================================== TIPO BAJA HABIENTE ===========================================
            dtTipoBajaHabiente = oPersonaService.MostrarBajaHabiente.Tables(0)
            'dtTipoBajaHabiente.Rows.InsertAt(getRowTodos(dtTipoBajaHabiente), 0)
            cmbTipoBaja.DataSource = dtTipoBajaHabiente
            cmbTipoBaja.DropDownList.DataMember = dtTipoBajaHabiente.Columns("DesBaja").ToString
            cmbTipoBaja.DropDownList.DisplayMember = dtTipoBajaHabiente.Columns("DesBaja").ToString
            cmbTipoBaja.DropDownList.ValueMember = dtTipoBajaHabiente.Columns("CodBaja").ToString
            cmbTipoBaja.DropDownList.Columns(0).DataMember = dtTipoBajaHabiente.Columns("CodBaja").ToString
            cmbTipoBaja.DropDownList.Columns(1).DataMember = dtTipoBajaHabiente.Columns("DesBaja").ToString
            dtTipoBajaHabiente = Nothing

            '=================================== TIPO DOC PATERNIDAD ==========================================
            dtTipoDocPat = oPersonaService.MostrarDocumentoPaternidad.Tables(0)
            cmbDocPat.DataSource = dtTipoDocPat
            cmbDocPat.DropDownList.DataMember = dtTipoDocPat.Columns("DesDocPat").ToString
            cmbDocPat.DropDownList.DisplayMember = dtTipoDocPat.Columns("DesDocPat").ToString
            cmbDocPat.DropDownList.ValueMember = dtTipoDocPat.Columns("CodDocPat").ToString
            cmbDocPat.DropDownList.Columns(0).DataMember = dtTipoDocPat.Columns("CodDocPat").ToString
            cmbDocPat.DropDownList.Columns(1).DataMember = dtTipoDocPat.Columns("DesDocPat").ToString
            dtTipoDocPat = Nothing

            '==================================== TIPO DE DOCUMENTO ==========================================
            dtTipoDocFam = oPersonaService.MostrarTipoDocumento.Tables(0)
            cmbTipoDocFam.DataSource = dtTipoDocFam
            cmbTipoDocFam.DropDownList.DataMember = dtTipoDocFam.Columns("AbrDoc").ToString
            cmbTipoDocFam.DropDownList.DisplayMember = dtTipoDocFam.Columns("AbrDoc").ToString
            cmbTipoDocFam.DropDownList.ValueMember = dtTipoDocFam.Columns("CodDoc").ToString
            cmbTipoDocFam.DropDownList.Columns(0).DataMember = dtTipoDocFam.Columns("CodDoc").ToString
            cmbTipoDocFam.DropDownList.Columns(1).DataMember = dtTipoDocFam.Columns("AbrDoc").ToString
            dtTipoDocFam = Nothing

            '========================================= TIPO VÍA ===============================================
            dtTipoViaFam = oPersonaService.MostrarTipoVias.Tables(0)
            cmbTipoViaFam.DataSource = dtTipoViaFam
            cmbTipoViaFam.DropDownList.DataMember = dtTipoViaFam.Columns("AbrVia").ToString
            cmbTipoViaFam.DropDownList.DisplayMember = dtTipoViaFam.Columns("AbrVia").ToString
            cmbTipoViaFam.DropDownList.ValueMember = dtTipoViaFam.Columns("CodVia").ToString
            cmbTipoViaFam.DropDownList.Columns(0).DataMember = dtTipoViaFam.Columns("CodVia").ToString
            cmbTipoViaFam.DropDownList.Columns(1).DataMember = dtTipoViaFam.Columns("AbrVia").ToString
            dtTipoViaFam = Nothing

            '======================================= TIPO VÍNCULO =============================================
            dtTipoVinculo = oPersonaService.MostrarTipoVinculos.Tables(0)
            cmbVinculoFam.DataSource = dtTipoVinculo
            cmbVinculoFam.DropDownList.DataMember = dtTipoVinculo.Columns("DesVinculo").ToString
            cmbVinculoFam.DropDownList.DisplayMember = dtTipoVinculo.Columns("DesVinculo").ToString
            cmbVinculoFam.DropDownList.ValueMember = dtTipoVinculo.Columns("CodVinculo").ToString
            cmbVinculoFam.DropDownList.Columns(0).DataMember = dtTipoVinculo.Columns("CodVinculo").ToString
            cmbVinculoFam.DropDownList.Columns(1).DataMember = dtTipoVinculo.Columns("DesVinculo").ToString
            dtTipoVinculo = Nothing

            '======================================= TIPO ZONA =============================================
            dtTipoZonaFam = oPersonaService.MostrarTipoZonas.Tables(0)
            cmbTipoZonaFam.DataSource = dtTipoZonaFam
            cmbTipoZonaFam.DropDownList.DataMember = dtTipoZonaFam.Columns("AbrZona").ToString
            cmbTipoZonaFam.DropDownList.DisplayMember = dtTipoZonaFam.Columns("AbrZona").ToString
            cmbTipoZonaFam.DropDownList.ValueMember = dtTipoZonaFam.Columns("CodZona").ToString
            cmbTipoZonaFam.DropDownList.Columns(0).DataMember = dtTipoZonaFam.Columns("CodZona").ToString
            cmbTipoZonaFam.DropDownList.Columns(1).DataMember = dtTipoZonaFam.Columns("AbrZona").ToString
            dtTipoZonaFam = Nothing

            '////////////////////////////////////////////////////////////////////// INSTRUCCION /////////////////////////////////////////////////////////////////////////////////////////

            '=================================== NIVEL DE ESTUDIOS ===========================================
            dtNivelEstudio = oCapacitacionService.MostrarNivelesEstudioRealizado().Tables(0)
            cmbNivelEst.DataSource = dtNivelEstudio
            cmbNivelEst.DropDownList.DataMember = dtNivelEstudio.Columns("DesNivel").ToString
            cmbNivelEst.DropDownList.DisplayMember = dtNivelEstudio.Columns("DesNivel").ToString
            cmbNivelEst.DropDownList.ValueMember = dtNivelEstudio.Columns("CodNivel").ToString
            cmbNivelEst.DropDownList.Columns(0).DataMember = dtNivelEstudio.Columns("CodNivel").ToString
            cmbNivelEst.DropDownList.Columns(1).DataMember = dtNivelEstudio.Columns("DesNivel").ToString
            cmbNivelEst.DropDownList.Columns(2).DataMember = dtNivelEstudio.Columns("AbrNivel").ToString
            dtNivelEstudio = Nothing

            '/////////////////////////////////////////////////////////////////////////// IDIOMA /////////////////////////////////////////////////////////////////////////////////////////////

            '------------------------------------------------------------------------ TIPO DE IDIOMA -----------------------------------------------------------------------------------------
            dtIdioma = New DataTable
            dtIdioma.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtIdioma.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtIdioma.Rows.Add(New Object() {"1", "Español"}) ', New DateTime(2008, 2, 5)
            dtIdioma.Rows.Add(New Object() {"2", "Inglés"})
            dtIdioma.Rows.Add(New Object() {"3", "Alemán"})
            dtIdioma.Rows.Add(New Object() {"4", "Italiano"})
            dtIdioma.Rows.Add(New Object() {"5", "Portugués"})
            dtIdioma.Rows.Add(New Object() {"6", "Francés"})

            cmbIdioma.DataSource = dtIdioma
            cmbIdioma.DropDownList.DataMember = dtIdioma.Columns("nombre").ToString
            cmbIdioma.DropDownList.DisplayMember = dtIdioma.Columns("nombre").ToString
            cmbIdioma.DropDownList.ValueMember = dtIdioma.Columns("nombre").ToString
            cmbIdioma.DropDownList.Columns(0).DataMember = dtIdioma.Columns("codigo").ToString
            cmbIdioma.DropDownList.Columns(1).DataMember = dtIdioma.Columns("nombre").ToString
            dtIdioma = Nothing

            '------------------------------------------------------------------------ NIVEL IDIOMA -----------------------------------------------------------------------------------------
            dtNivelIdio = New DataTable
            dtNivelIdio.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtNivelIdio.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtNivelIdio.Rows.Add(New Object() {"1", "Nativo"}) ', New DateTime(2008, 2, 5)
            dtNivelIdio.Rows.Add(New Object() {"2", "Básico"})
            dtNivelIdio.Rows.Add(New Object() {"3", "Intermedio"})
            dtNivelIdio.Rows.Add(New Object() {"4", "Avanzado"})

            cmbNivelIdioma.DataSource = dtNivelIdio
            cmbNivelIdioma.DropDownList.DataMember = dtNivelIdio.Columns("nombre").ToString
            cmbNivelIdioma.DropDownList.DisplayMember = dtNivelIdio.Columns("nombre").ToString
            cmbNivelIdioma.DropDownList.ValueMember = dtNivelIdio.Columns("nombre").ToString
            cmbNivelIdioma.DropDownList.Columns(0).DataMember = dtNivelIdio.Columns("codigo").ToString
            cmbNivelIdioma.DropDownList.Columns(1).DataMember = dtNivelIdio.Columns("nombre").ToString
            dtNivelIdio = Nothing

            '//////////////////////////////////////////////////////////////////////// INFORMATICA //////////////////////////////////////////////////////////////////////////////////////////

            '-------------------------------------------------------------------------- PROGRAMA ---------------------------------------------------------------------------------------------
            dtPrograma = oPersonaService.MostrarProgramaInformatica().Tables(0)
            cmbPrograma.DataSource = dtPrograma
            cmbPrograma.DropDownList.DataMember = dtPrograma.Columns("DesPrograma").ToString
            cmbPrograma.DropDownList.DisplayMember = dtPrograma.Columns("DesPrograma").ToString
            cmbPrograma.DropDownList.ValueMember = dtPrograma.Columns("IdPrograma").ToString
            cmbPrograma.DropDownList.Columns(0).DataMember = dtPrograma.Columns("IdPrograma").ToString
            cmbPrograma.DropDownList.Columns(1).DataMember = dtPrograma.Columns("DesPrograma").ToString
            dtPrograma = Nothing

            '--------------------------------------------------------------------- NIVEL INFORMÁTICA ------------------------------------------------------------------------------------
            dtNivelInfo = New DataTable
            dtNivelInfo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtNivelInfo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtNivelInfo.Rows.Add(New Object() {"1", "Básico"}) ', New DateTime(2008, 2, 5)
            dtNivelInfo.Rows.Add(New Object() {"2", "Intermedio"})
            dtNivelInfo.Rows.Add(New Object() {"3", "Avanzado"})

            cmbNivelInfor.DataSource = dtNivelInfo
            cmbNivelInfor.DropDownList.DataMember = dtNivelInfo.Columns("nombre").ToString
            cmbNivelInfor.DropDownList.DisplayMember = dtNivelInfo.Columns("nombre").ToString
            cmbNivelInfor.DropDownList.ValueMember = dtNivelInfo.Columns("nombre").ToString
            cmbNivelInfor.DropDownList.Columns(0).DataMember = dtNivelInfo.Columns("codigo").ToString
            cmbNivelInfor.DropDownList.Columns(1).DataMember = dtNivelInfo.Columns("nombre").ToString
            dtNivelInfo = Nothing

            '//////////////////////////////////////////////////////////////////////// EXP. LABORAL //////////////////////////////////////////////////////////////////////////////////////////

            '=======================================MONEDA ===============================================
            dtMonExpLab = oMaestroService.MostrarMonedas.Tables(0)
            cmbMonExpLab.DataSource = dtMonExpLab
            cmbMonExpLab.DropDownList.DataMember = dtMonExpLab.Columns("AbrMon").ToString
            cmbMonExpLab.DropDownList.DisplayMember = dtMonExpLab.Columns("AbrMon").ToString
            cmbMonExpLab.DropDownList.ValueMember = dtMonExpLab.Columns("CodMon").ToString
            cmbMonExpLab.DropDownList.Columns(0).DataMember = dtMonExpLab.Columns("CodMon").ToString
            cmbMonExpLab.DropDownList.Columns(1).DataMember = dtMonExpLab.Columns("AbrMon").ToString
            dtMonExpLab = Nothing

            '//////////////////////////////////////////////////////////////////////// CAPACITACIÓN //////////////////////////////////////////////////////////////////////////////////////////

            ''======================================== TIPO =================================================
            'dtTipoCapacitacion = oCapacitacionService.MostrarTipos()
            'cmbTipoCapac.DataSource = dtTipoCapacitacion
            'cmbTipoCapac.DropDownList.DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            'cmbTipoCapac.DropDownList.DisplayMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            'cmbTipoCapac.DropDownList.ValueMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            'cmbTipoCapac.DropDownList.Columns(0).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            'cmbTipoCapac.DropDownList.Columns(1).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            'dtTipoCapacitacion = Nothing

            ''=======================================MONEDA ===============================================
            'dtMonCapacitacion = oMaestroService.MostrarMonedas.Tables(0)
            'cmbMonCapac.DataSource = dtMonCapacitacion
            'cmbMonCapac.DropDownList.DataMember = dtMonCapacitacion.Columns("AbrMon").ToString
            'cmbMonCapac.DropDownList.DisplayMember = dtMonCapacitacion.Columns("AbrMon").ToString
            'cmbMonCapac.DropDownList.ValueMember = dtMonCapacitacion.Columns("CodMon").ToString
            'cmbMonCapac.DropDownList.Columns(0).DataMember = dtMonCapacitacion.Columns("CodMon").ToString
            'cmbMonCapac.DropDownList.Columns(1).DataMember = dtMonCapacitacion.Columns("AbrMon").ToString
            'dtMonCapacitacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), "").Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ==========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            dtCentroCosto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOpciones()
        Try
            tpfamiliares.Enabled = IIf(state_button = True And edicion = False, True, False)
            tpInstruccion.Enabled = IIf(state_button = True And edicion = False, True, False)
            tpExpLaboral.Enabled = IIf(state_button = True And edicion = False, True, False)
            'tpCapacitaciones.Enabled = If(state_button = True And edicion = False, True, False)
            tpCese.Enabled = IIf(state_button = True And edicion = False, True, False)

            biEditar.Enabled = IIf(editable, Not edicion, False)
            biGrabar.Enabled = edicion
            biDeshacer.Enabled = edicion 'IIf(edicion And state_button, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////////// FICHA GENERAL /////////////////////////////////////////////////////////////////////////////////////////
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    Private Sub FichaGeneral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtIdPersona.KeyPress _
            , cmbNacionalidad.KeyPress _
            , txtApePaterno.KeyPress _
            , txtApeMaterno.KeyPress _
            , txtNombre1.KeyPress _
            , txtNombre2.KeyPress _
            , txtFechaNac.KeyPress _
            , cmbEstadoCivil.KeyPress _
            , cmbTipoDoc.KeyPress _
            , txtNumDoc.KeyPress _
            , rbFemenino.KeyPress _
            , rbMasculino.KeyPress _
            , txtTelefonos.KeyPress _
            , txtEmail.KeyPress _
            , cbDomiciliado.KeyPress _
            , cbDomiciliado.KeyPress _
            , txtUbigeo.KeyPress _
            , btnUbigeo.KeyPress _
            , txtReferencia.KeyPress _
            , cmbTipoVia.KeyPress _
            , txtNomVia.KeyPress _
            , txtNroVia.KeyPress _
            , cmbTipoZona.KeyPress _
            , txtNomZona.KeyPress _
            , txtInterior.KeyPress _
            , txtEmpresa.KeyPress _
            , txtCarnet.KeyPress _
            , txtAnexo.KeyPress _
            , cmbArea.KeyPress _
            , cmbUnidad.KeyPress _
            , cmbCentroCosto.KeyPress _
            , cmbClase.KeyPress _
            , cmbSituacionEspecial.KeyPress _
            , cmbCargo.KeyPress _
            , cbVigente.KeyPress _
            , cbMarcaTarjeta.KeyPress _
            , txtFechaIngreso.KeyPress _
            , txtFechaCese.KeyPress _
            , txtFecIngContrato.KeyPress _
            , txtFecCeseContrato.KeyPress _
            , txtFecIngEstable.KeyPress _
            , txtFecIniPlanilla.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUbigeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbigeo.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnUbigeo.Enabled = True Then
                e.Handled = True
                btnUbigeo_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Desactivar()
        Try
            cmbNacionalidad.ReadOnly = True
            cmbNacionalidad.BackColor = System.Drawing.Color.PowderBlue
            txtApePaterno.ReadOnly = True
            txtApePaterno.BackColor = System.Drawing.Color.PowderBlue
            txtApeMaterno.ReadOnly = True
            txtApeMaterno.BackColor = System.Drawing.Color.PowderBlue
            txtNombre1.ReadOnly = True
            txtNombre1.BackColor = System.Drawing.Color.PowderBlue
            txtNombre2.ReadOnly = True
            txtNombre2.BackColor = System.Drawing.Color.PowderBlue
            txtFechaNac.ReadOnly = True
            txtFechaNac.BackColor = System.Drawing.Color.PowderBlue
            cmbEstadoCivil.ReadOnly = True
            cmbEstadoCivil.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoDoc.ReadOnly = True
            cmbTipoDoc.BackColor = System.Drawing.Color.PowderBlue
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.Color.PowderBlue
            gbSexo.Enabled = False
            txtTelefonos.ReadOnly = True
            txtTelefonos.BackColor = System.Drawing.Color.PowderBlue
            txtEmail.ReadOnly = True
            txtEmail.BackColor = System.Drawing.Color.PowderBlue
            cbDomiciliado.Enabled = False
            btnBuscarFoto.Enabled = False
            btnUbigeo.Enabled = False
            txtReferencia.ReadOnly = True
            txtReferencia.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoVia.ReadOnly = True
            cmbTipoVia.BackColor = System.Drawing.Color.PowderBlue
            txtNomVia.ReadOnly = True
            txtNomVia.BackColor = System.Drawing.Color.PowderBlue
            txtNroVia.ReadOnly = True
            txtNroVia.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoZona.ReadOnly = True
            cmbTipoZona.BackColor = System.Drawing.Color.PowderBlue
            txtNomZona.ReadOnly = True
            txtNomZona.BackColor = System.Drawing.Color.PowderBlue
            txtInterior.ReadOnly = True
            txtInterior.BackColor = System.Drawing.Color.PowderBlue
            txtCarnet.ReadOnly = True
            txtCarnet.BackColor = System.Drawing.Color.PowderBlue
            txtAnexo.ReadOnly = True
            txtAnexo.BackColor = System.Drawing.Color.PowderBlue
            cmbUnidad.ReadOnly = True
            cmbUnidad.BackColor = System.Drawing.Color.PowderBlue
            cmbArea.ReadOnly = True
            cmbArea.BackColor = System.Drawing.Color.PowderBlue
            cmbCentroCosto.ReadOnly = True
            cmbCentroCosto.BackColor = System.Drawing.Color.PowderBlue
            cmbClase.ReadOnly = True
            cmbClase.BackColor = System.Drawing.Color.PowderBlue
            cmbSituacionEspecial.ReadOnly = True
            cmbSituacionEspecial.BackColor = System.Drawing.Color.PowderBlue
            cmbCargo.ReadOnly = True
            cmbCargo.BackColor = System.Drawing.Color.PowderBlue
            cbVigente.Enabled = False
            cbMarcaTarjeta.Enabled = False
            'cbSaludVida.Enabled = False
            txtFechaIngreso.ReadOnly = True
            txtFechaIngreso.BackColor = System.Drawing.Color.PowderBlue
            txtFechaCese.ReadOnly = True
            txtFechaCese.BackColor = System.Drawing.Color.PowderBlue
            txtFecIngContrato.ReadOnly = True
            txtFecIngContrato.BackColor = System.Drawing.Color.PowderBlue
            txtFecCeseContrato.ReadOnly = True
            txtFecCeseContrato.BackColor = System.Drawing.Color.PowderBlue
            txtFecIngEstable.ReadOnly = True
            txtFecIngEstable.BackColor = System.Drawing.Color.PowderBlue
            txtFecIniPlanilla.ReadOnly = True
            txtFecIniPlanilla.BackColor = System.Drawing.Color.PowderBlue
            edicion = False
            EnableOpciones()
            cmbNacionalidad.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Activar()
        Try
            cmbNacionalidad.ReadOnly = False
            cmbNacionalidad.BackColor = System.Drawing.SystemColors.Window
            txtApePaterno.ReadOnly = False
            txtApePaterno.BackColor = System.Drawing.SystemColors.Window
            txtApeMaterno.ReadOnly = False
            txtApeMaterno.BackColor = System.Drawing.SystemColors.Window
            txtNombre1.ReadOnly = False
            txtNombre1.BackColor = System.Drawing.SystemColors.Window
            txtNombre2.ReadOnly = False
            txtNombre2.BackColor = System.Drawing.SystemColors.Window
            txtFechaNac.ReadOnly = False
            txtFechaNac.BackColor = System.Drawing.SystemColors.Window
            cmbEstadoCivil.ReadOnly = False
            cmbEstadoCivil.BackColor = System.Drawing.SystemColors.Window
            cmbTipoDoc.ReadOnly = False
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            gbSexo.Enabled = True
            txtTelefonos.ReadOnly = False
            txtTelefonos.BackColor = System.Drawing.SystemColors.Window
            txtEmail.ReadOnly = False
            txtEmail.BackColor = System.Drawing.SystemColors.Window
            cbDomiciliado.Enabled = True
            btnBuscarFoto.Enabled = True
            btnUbigeo.Enabled = True
            txtReferencia.ReadOnly = False
            txtReferencia.BackColor = System.Drawing.SystemColors.Window
            cmbTipoVia.ReadOnly = False
            cmbTipoVia.BackColor = System.Drawing.SystemColors.Window
            txtNomVia.ReadOnly = False
            txtNomVia.BackColor = System.Drawing.SystemColors.Window
            txtNroVia.ReadOnly = False
            txtNroVia.BackColor = System.Drawing.SystemColors.Window
            cmbTipoZona.ReadOnly = False
            cmbTipoZona.BackColor = System.Drawing.SystemColors.Window
            txtNomZona.ReadOnly = False
            txtNomZona.BackColor = System.Drawing.SystemColors.Window
            txtInterior.ReadOnly = False
            txtInterior.BackColor = System.Drawing.SystemColors.Window
            txtCarnet.ReadOnly = False
            txtCarnet.BackColor = System.Drawing.SystemColors.Window
            txtAnexo.ReadOnly = False
            txtAnexo.BackColor = System.Drawing.SystemColors.Window
            cmbUnidad.ReadOnly = False
            cmbUnidad.BackColor = System.Drawing.SystemColors.Window
            cmbArea.ReadOnly = False
            cmbArea.BackColor = System.Drawing.SystemColors.Window
            cmbCentroCosto.ReadOnly = False
            cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
            cmbClase.ReadOnly = False
            cmbClase.BackColor = System.Drawing.SystemColors.Window
            cmbSituacionEspecial.ReadOnly = False
            cmbSituacionEspecial.BackColor = System.Drawing.SystemColors.Window
            cmbCargo.ReadOnly = False
            cmbCargo.BackColor = System.Drawing.SystemColors.Window
            cbVigente.Enabled = True
            cbMarcaTarjeta.Enabled = True
            'cbSaludVida.Enabled = True
            txtFechaIngreso.ReadOnly = False
            txtFechaIngreso.BackColor = System.Drawing.SystemColors.Window
            txtFechaCese.ReadOnly = False
            txtFechaCese.BackColor = System.Drawing.SystemColors.Window
            txtFecIngContrato.ReadOnly = False
            txtFecIngContrato.BackColor = System.Drawing.SystemColors.Window
            txtFecCeseContrato.ReadOnly = False
            txtFecCeseContrato.BackColor = System.Drawing.SystemColors.Window
            txtFecIngEstable.ReadOnly = False
            txtFecIngEstable.BackColor = System.Drawing.SystemColors.Window
            txtFecIniPlanilla.ReadOnly = False
            txtFecIniPlanilla.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            EnableOpciones()
            cmbNacionalidad.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Finalizar()
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbNacionalidad.Value) = "" Then
                MsgBox("Debe Ingresar la Nacionalidad.", MsgBoxStyle.Information, "Información")
                cmbNacionalidad.Focus()
                Return False
            ElseIf toBlank(txtApePaterno.Text) = "" Then
                MsgBox("Debe Ingresar el Apellido Paterno.", MsgBoxStyle.Information, "Información")
                txtApePaterno.Focus()
                Return False
            ElseIf toBlank(txtApeMaterno.Text) = "" Then
                MsgBox("Debe Ingresar el Apellido Materno.", MsgBoxStyle.Information, "Información")
                txtApeMaterno.Focus()
                Return False
            ElseIf toBlank(txtNombre1.Text) = "" Then
                MsgBox("Debe Ingresar el Nombre.", MsgBoxStyle.Information, "Información")
                txtNombre1.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf toBlank(cmbEstadoCivil.Value) = "" Then
                MsgBox("Debe Ingresar el Estado Civil.", MsgBoxStyle.Information, "Información")
                cmbEstadoCivil.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New PersonaService.Persona
                Dim Nacionalidad As New PersonaService.Nacionalidad
                Dim TipoDoc As New PersonaService.TipoDocumentoId
                Dim EstadoCivil As New PersonaService.EstadoCivil
                Dim Ubigeo As New PersonaService.Ubigeo
                Dim TipoVia As New PersonaService.TipoVia
                Dim TipoZona As New PersonaService.TipoZona
                Dim Empresa As New PersonaService.Empresa
                Dim Area As New PersonaService.Area
                Dim UnidadNegocio As New PersonaService.UnidadNegocio
                Dim CentroCosto As New PersonaService.CentroCosto
                Dim Clase As New PersonaService.Clase
                Dim Cargo As New PersonaService.Cargo
                Dim SituacionEspecial As New PersonaService.SituacionEspecial

                registro.IdPer = IdPersona
                Nacionalidad.CodNac = cmbNacionalidad.Value
                registro.Nacionalidad = Nacionalidad
                registro.ApePat = txtApePaterno.Text
                registro.ApeMat = txtApeMaterno.Text
                registro.NomPer1 = txtNombre1.Text
                registro.NomPer2 = txtNombre2.Text
                registro.FecNac = txtFechaNac.Value
                EstadoCivil.IdEstado = cmbEstadoCivil.Value
                registro.EstadoCivil = EstadoCivil
                TipoDoc.CodDoc = cmbTipoDoc.Value
                registro.TipoDocumentoId = TipoDoc
                registro.NumDoc = txtNumDoc.Text
                If rbMasculino.Checked = True Then
                    registro.Sexo = 1
                ElseIf rbFemenino.Checked = True Then
                    registro.Sexo = 2
                End If
                registro.Telefonos = txtTelefonos.Text
                registro.Email = txtEmail.Text
                registro.Domiciliado = cbDomiciliado.Checked

                Ubigeo.CodUbigeo = IIf(CodUbigeo = "", Nothing, CodUbigeo)
                registro.Ubigeo = Ubigeo
                registro.Referencia = txtReferencia.Text
                TipoVia.CodVia = IIf(cmbTipoVia.Value = "", Nothing, cmbTipoVia.Value)
                registro.TipoVia = TipoVia
                registro.NomVia = txtNomVia.Text
                registro.NumVia = txtNroVia.Text
                TipoZona.CodZona = IIf(cmbTipoZona.Value = "", Nothing, cmbTipoZona.Value)
                registro.TipoZona = TipoZona
                registro.NomZona = txtNomZona.Text
                registro.Interior = txtInterior.Text

                Empresa.CodEmp = CodEmp
                registro.Empresa = Empresa
                registro.Carnet = txtCarnet.Text
                registro.Anexo = txtAnexo.Text
                UnidadNegocio.IdUnidad = cmbUnidad.Value
                Area.CodArea = cmbArea.Value
                Area.UnidadNegocio = UnidadNegocio
                CentroCosto.CodCentro = cmbCentroCosto.Value
                CentroCosto.Area = Area
                registro.CentroCosto = CentroCosto
                Clase.CodClas = cmbClase.Value
                registro.Clase = Clase
                SituacionEspecial.CodSit = cmbSituacionEspecial.Value
                registro.SituacionEspecial = SituacionEspecial
                Cargo.CodCargo = cmbCargo.Value
                registro.Cargo = Cargo
                registro.Vigente = cbVigente.Checked
                registro.Marca = cbMarcaTarjeta.Checked
                'registro.SaludVida = cbSaludVida.Checked

                registro.FecIngreso = IIf(txtFechaIngreso.Text = "", Nothing, txtFechaIngreso.Value)
                registro.FecIniContrato = IIf(txtFecIngContrato.Text = "", Nothing, txtFecIngContrato.Value)
                registro.FecIniEstable = IIf(txtFecIngEstable.Text = "", Nothing, txtFecIngEstable.Value)

                registro.FecCese = IIf(txtFechaCese.Text = "", Nothing, txtFechaCese.Value)
                registro.FecFinContrato = IIf(txtFecCeseContrato.Text = "", Nothing, txtFecCeseContrato.Value)
                registro.FecIniPlanilla = IIf(txtFecIniPlanilla.Text = "", Nothing, txtFecIniPlanilla.Value)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today

                registro.Foto = utils.ImageToByteArray(pbFoto.Image)


                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PersonaService.Persona
            registro = oPersonaService.Obtener(IdPersona)

            IdPersona = registro.IdPer

            txtIdPersona.Text = registro.IdPer
            cmbNacionalidad.Value = registro.Nacionalidad.CodNac
            txtApePaterno.Text = registro.ApePat
            txtApeMaterno.Text = registro.ApeMat
            txtNombre1.Text = registro.NomPer1
            txtNombre2.Text = registro.NomPer2
            txtFechaNac.Value = registro.FecNac
            cmbEstadoCivil.Value = registro.EstadoCivil.IdEstado
            cmbTipoDoc.Value = registro.TipoDocumentoId.CodDoc
            txtNumDoc.Text = registro.NumDoc
            If registro.Sexo = 1 Then
                rbMasculino.Checked = True
                rbFemenino.Checked = False
            Else
                rbFemenino.Checked = True
                rbMasculino.Checked = False
            End If
            txtTelefonos.Text = registro.Telefonos
            txtEmail.Text = registro.Email
            cbDomiciliado.Checked = registro.Domiciliado

            Me.pbFoto.Image = utils.ByteArrayToImage(registro.Foto)

            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = registro.Ubigeo.Departamento.NomDpto + " - " + registro.Ubigeo.Provincia.NomProv + " - " + registro.Ubigeo.Distrito.NomDist
            txtReferencia.Text = registro.Referencia
            cmbTipoVia.Value = registro.TipoVia.CodVia
            txtNomVia.Text = registro.NomVia
            txtNroVia.Text = registro.NumVia
            cmbTipoZona.Value = registro.TipoZona.CodZona
            txtNomZona.Text = registro.NomZona
            txtInterior.Text = registro.Interior

            CodEmp = registro.Empresa.CodEmp
            txtEmpresa.Text = registro.Empresa.DesEmp
            txtCarnet.Text = registro.Carnet
            txtAnexo.Text = registro.Anexo
            cmbUnidad.Value = registro.CentroCosto.Area.UnidadNegocio.IdUnidad
            cmbArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            cmbClase.Value = registro.Clase.CodClas
            cmbSituacionEspecial.Value = registro.SituacionEspecial.CodSit
            cmbCargo.Value = registro.Cargo.CodCargo

            cbVigente.Checked = registro.Vigente
            cbMarcaTarjeta.Checked = registro.Marca
            'cbSaludVida.Checked = registro.SaludVida

            If registro.FecIngreso.ToString = "" Then
                txtFechaIngreso.IsNullDate = True
            Else
                txtFechaIngreso.IsNullDate = False
                txtFechaIngreso.Value = registro.FecIngreso
            End If
            If registro.FecIniContrato.ToString = "" Then
                txtFecIngContrato.IsNullDate = True
            Else
                txtFecIngContrato.IsNullDate = False
                txtFecIngContrato.Value = registro.FecIniContrato
            End If

            If registro.FecIniEstable.ToString = "" Then
                txtFecIngEstable.IsNullDate = True
            Else
                txtFecIngEstable.IsNullDate = False
                txtFecIngEstable.Value = registro.FecIniEstable
            End If

            If registro.FecCese.ToString = "" Then
                txtFechaCese.IsNullDate = True
            Else
                txtFechaCese.IsNullDate = False
                txtFechaCese.Value = registro.FecCese
            End If
            If registro.FecFinContrato.ToString = "" Then
                txtFecCeseContrato.IsNullDate = True
            Else
                txtFecCeseContrato.IsNullDate = False
                txtFecCeseContrato.Value = registro.FecFinContrato
            End If
            If registro.FecIniPlanilla.ToString = "" Then
                txtFecIniPlanilla.IsNullDate = True
            Else
                txtFecIniPlanilla.IsNullDate = False
                txtFecIniPlanilla.Value = registro.FecIniPlanilla
            End If

            Me.Text = "Colaborador: " + Chr(34) + registro.ApeNom + Chr(34)

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As PersonaService.Persona)
        Try
            Dim estado_process As Integer
            estado_process = oPersonaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPersona = estado_process
                MsgBox("Se inserto el Colaborador Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PersonaService.Persona)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Colaborador Correctamente")
                Desactivar()
                ObtenerRegistro()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbigeo.Click
        Try
            Dim frm As New frmBuscarUbigeo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                CodUbigeo = frm.CodUbigeo
                txtUbigeo.Text = frm.Nombre
            End If
            txtUbigeo.Select()
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR UBIGEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '//////////////////////////////////////////////////////////////////////////// FAMILIARES ///////////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    Private Sub Familiares_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtNomFam.KeyPress _
                  , txtApePatFam.KeyPress _
                  , txtApeMatFam.KeyPress _
                  , txtFecNacFam.KeyPress _
                  , cmbTipoDocFam.KeyPress _
                  , txtNumDocFam.KeyPress _
                  , rbMasculinoF.KeyPress _
                  , rbFemeninoF.KeyPress _
                  , cmbVinculoFam.KeyPress _
                  , txtOcupacion.KeyPress _
                  , cbDerechoHab.KeyPress _
                  , cmbDocPat.KeyPress _
                  , txtNumDocPat.KeyPress _
                  , cbDerechoHabAct.KeyPress _
                  , txtFechaAlta.KeyPress _
                  , cmbTipoBaja.KeyPress _
                  , txtFechaBaja.KeyPress _
                  , txtResDirIncHijoME.KeyPress _
                  , cbOtroDomicilio.KeyPress _
                  , cmbTipoViaFam.KeyPress _
                  , txtNomViaFam.KeyPress _
                  , txtNroViaFam.KeyPress _
                  , cmbTipoZonaFam.KeyPress _
                  , txtNomZonaFam.KeyPress _
                  , txtInteriorFam.KeyPress _
                  , txtUbigeoFam.KeyPress _
                  , txtReferenciaFam.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ListarFamiliares()
        Try
            dtDatosFamiliares = oPersonaService.MostrarFamiliares(IdPersona).Tables(0)
            dgvFamiliares.DataSource = dtDatosFamiliares
            EnableOpcionesFamiliar()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR FAMILIARES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossFamiliares(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdFamilia").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS FAMILIAR]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesFamiliar()
        Try
            If dgvFamiliares.RowCount > 0 Then
                miElimFam.Enabled = True
                miEditFam.Enabled = True
            Else
                miElimFam.Enabled = False
                miEditFam.Enabled = False
            End If
            biGrabarFam.Enabled = edicionFamiliares
            biDeshacerFam.Enabled = edicionFamiliares

            dgvFamiliares.Enabled = IIf(Not edicionFamiliares, True, False)
            cmOpFamiliar.Enabled = IIf(Not edicionFamiliares, True, False)

            tpFichaGeneral.Enabled = IIf(edicionFamiliares = False, True, False)
            tpInstruccion.Enabled = IIf(edicionFamiliares = False, True, False)
            tpExpLaboral.Enabled = IIf(edicionFamiliares = False, True, False)
            'tpCapacitaciones.Enabled = IIf(edicionFamiliares = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES FAMILIARES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarFamiliar()
        Try
            txtNomFam.Text = ""
            txtApePatFam.Text = ""
            txtApeMatFam.Text = ""
            txtFecNacFam.IsNullDate = True
            cmbTipoDocFam.Text = ""
            txtNumDocFam.Text = ""
            rbFemeninoF.Checked = False
            rbMasculinoF.Checked = False
            cmbVinculoFam.Text = ""
            txtOcupacion.Text = ""

            cbDerechoHab.Checked = False
            cmbDocPat.Text = ""
            txtNumDocPat.Text = ""

            cbDerechoHabAct.Checked = False
            txtFechaAlta.IsNullDate = True
            cmbTipoBaja.Text = ""
            txtFechaBaja.IsNullDate = True
            txtResDirIncHijoME.Text = ""

            cbOtroDomicilio.Checked = False
            cmbTipoViaFam.Text = ""
            txtNomViaFam.Text = ""
            txtNroViaFam.Text = ""
            cmbTipoZonaFam.Text = ""
            txtNomZonaFam.Text = ""
            txtInteriorFam.Text = ""
            CodUbigeoFam = ""
            txtUbigeoFam.Text = ""
            txtReferenciaFam.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarFamiliar()
        Try
            'LimpiarFamiliar()
            txtNomFam.ReadOnly = True
            txtNomFam.BackColor = System.Drawing.Color.PowderBlue
            txtApePatFam.ReadOnly = True
            txtApePatFam.BackColor = System.Drawing.Color.PowderBlue
            txtApeMatFam.ReadOnly = True
            txtApeMatFam.BackColor = System.Drawing.Color.PowderBlue
            txtFecNacFam.ReadOnly = True
            txtFecNacFam.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoDocFam.ReadOnly = True
            cmbTipoDocFam.BackColor = System.Drawing.Color.PowderBlue
            txtNumDocFam.ReadOnly = True
            txtNumDocFam.BackColor = System.Drawing.Color.PowderBlue
            gbSexoFam.Enabled = False
            cmbVinculoFam.ReadOnly = True
            cmbVinculoFam.BackColor = System.Drawing.Color.PowderBlue
            txtOcupacion.ReadOnly = True
            txtOcupacion.BackColor = System.Drawing.Color.PowderBlue

            cbDerechoHab.Enabled = False
            cmbDocPat.ReadOnly = True
            cmbDocPat.BackColor = System.Drawing.Color.PowderBlue
            txtNumDocPat.ReadOnly = True
            txtNumDocPat.BackColor = System.Drawing.Color.PowderBlue

            cbDerechoHabAct.Enabled = False
            txtFechaAlta.ReadOnly = True
            txtFechaAlta.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoBaja.ReadOnly = True
            cmbTipoBaja.BackColor = System.Drawing.Color.PowderBlue
            txtFechaBaja.ReadOnly = True
            txtFechaBaja.BackColor = System.Drawing.Color.PowderBlue
            txtResDirIncHijoME.ReadOnly = True
            txtResDirIncHijoME.BackColor = System.Drawing.Color.PowderBlue

            cbOtroDomicilio.Enabled = False
            cmbTipoViaFam.ReadOnly = True
            cmbTipoViaFam.BackColor = System.Drawing.Color.PowderBlue
            txtNomViaFam.ReadOnly = True
            txtNomViaFam.BackColor = System.Drawing.Color.PowderBlue
            txtNroViaFam.ReadOnly = True
            txtNroViaFam.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoZonaFam.ReadOnly = True
            cmbTipoZonaFam.BackColor = System.Drawing.Color.PowderBlue
            txtNomZonaFam.ReadOnly = True
            txtNomZonaFam.BackColor = System.Drawing.Color.PowderBlue
            txtInteriorFam.ReadOnly = True
            txtInteriorFam.BackColor = System.Drawing.Color.PowderBlue
            btnBuscarUbigeoFam.Enabled = False
            txtReferenciaFam.ReadOnly = True
            txtReferenciaFam.BackColor = System.Drawing.Color.PowderBlue

            edicionFamiliares = False
            EnableOpcionesFamiliar()
            dgvFamiliares.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActivarFamiliar()
        Try
            txtNomFam.ReadOnly = False
            txtNomFam.BackColor = System.Drawing.SystemColors.Window
            txtApePatFam.ReadOnly = False
            txtApePatFam.BackColor = System.Drawing.SystemColors.Window
            txtApeMatFam.ReadOnly = False
            txtApeMatFam.BackColor = System.Drawing.SystemColors.Window
            txtFecNacFam.ReadOnly = False
            txtFecNacFam.BackColor = System.Drawing.SystemColors.Window
            txtFecNacFam.IsNullDate = False
            txtFecNacFam.Value = Today
            cmbTipoDocFam.ReadOnly = False
            cmbTipoDocFam.BackColor = System.Drawing.SystemColors.Window
            cmbTipoDocFam.Value = "1"
            txtNumDocFam.ReadOnly = False
            txtNumDocFam.BackColor = System.Drawing.SystemColors.Window
            gbSexoFam.Enabled = True
            rbMasculinoF.Checked = True
            rbFemeninoF.Checked = False
            cmbVinculoFam.ReadOnly = False
            cmbVinculoFam.BackColor = System.Drawing.SystemColors.Window
            cmbVinculoFam.SelectedIndex = 0
            txtOcupacion.ReadOnly = False
            txtOcupacion.BackColor = System.Drawing.SystemColors.Window

            cbDerechoHab.Enabled = True
            cbDerechoHab.Checked = False

            cbOtroDomicilio.Enabled = True
            cbOtroDomicilio.Checked = False

            edicionFamiliares = True
            EnableOpcionesFamiliar()
            txtNomFam.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbDerechoHab_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDerechoHab.CheckedChanged
        If cbDerechoHab.Checked = True Then
            cmbDocPat.ReadOnly = False
            cmbDocPat.BackColor = System.Drawing.SystemColors.Window
            cmbDocPat.SelectedIndex = 0
            txtNumDocPat.ReadOnly = False
            txtNumDocPat.BackColor = System.Drawing.SystemColors.Window

            cbDerechoHabAct.Enabled = True
            cbDerechoHabAct.Checked = True
        ElseIf cbDerechoHab.Checked = False Then
            cmbDocPat.ReadOnly = True
            cmbDocPat.BackColor = System.Drawing.Color.PowderBlue
            cmbDocPat.Text = ""
            txtNumDocPat.ReadOnly = True
            txtNumDocPat.BackColor = System.Drawing.Color.PowderBlue

            cbDerechoHabAct.Enabled = False
            cbDerechoHabAct.Checked = False
        End If
    End Sub

    Private Sub cbDerechoHabAct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDerechoHabAct.CheckedChanged
        If cbDerechoHab.Checked = True Then
            cbDerechoHabAct.Enabled = True
            If cbDerechoHabAct.Checked = True Then
                txtFechaAlta.ReadOnly = False
                txtFechaAlta.BackColor = System.Drawing.SystemColors.Window
                txtFechaAlta.IsNullDate = False
                txtFechaAlta.Value = Today

                cmbTipoBaja.ReadOnly = True
                cmbTipoBaja.BackColor = System.Drawing.Color.PowderBlue
                cmbTipoBaja.Text = ""

                txtFechaBaja.ReadOnly = True
                txtFechaBaja.BackColor = System.Drawing.Color.PowderBlue
                txtFechaBaja.IsNullDate = True

                txtResDirIncHijoME.ReadOnly = False
                txtResDirIncHijoME.BackColor = System.Drawing.SystemColors.Window

            ElseIf cbDerechoHabAct.Checked = False Then
                txtFechaAlta.ReadOnly = True
                txtFechaAlta.BackColor = System.Drawing.Color.PowderBlue
                txtFechaAlta.IsNullDate = False

                cmbTipoBaja.ReadOnly = False
                cmbTipoBaja.BackColor = System.Drawing.SystemColors.Window
                cmbTipoBaja.SelectedIndex = 0

                txtFechaBaja.ReadOnly = False
                txtFechaBaja.BackColor = System.Drawing.SystemColors.Window
                txtFechaBaja.IsNullDate = False
                txtFechaBaja.Value = Today

                txtResDirIncHijoME.ReadOnly = True
                txtResDirIncHijoME.BackColor = System.Drawing.Color.PowderBlue
            End If
        Else
            cbDerechoHabAct.Enabled = False
            cbDerechoHabAct.Checked = False

            txtFechaAlta.ReadOnly = True
            txtFechaAlta.BackColor = System.Drawing.Color.PowderBlue
            txtFechaAlta.IsNullDate = True

            cmbTipoBaja.ReadOnly = True
            cmbTipoBaja.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoBaja.Text = ""

            txtFechaBaja.ReadOnly = True
            txtFechaBaja.BackColor = System.Drawing.Color.PowderBlue
            txtFechaBaja.IsNullDate = True

            txtResDirIncHijoME.ReadOnly = True
            txtResDirIncHijoME.BackColor = System.Drawing.Color.PowderBlue
        End If
        
    End Sub

    Private Sub cbOtroDomicilio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOtroDomicilio.CheckedChanged
        If cbOtroDomicilio.Checked = True Then
            cmbTipoViaFam.ReadOnly = False
            cmbTipoViaFam.BackColor = System.Drawing.SystemColors.Window
            cmbTipoViaFam.SelectedIndex = 0
            txtNomViaFam.ReadOnly = False
            txtNomViaFam.BackColor = System.Drawing.SystemColors.Window
            txtNroViaFam.ReadOnly = False
            txtNroViaFam.BackColor = System.Drawing.SystemColors.Window
            cmbTipoZonaFam.ReadOnly = False
            cmbTipoZonaFam.BackColor = System.Drawing.SystemColors.Window
            cmbTipoZonaFam.SelectedIndex = 0
            txtNomZonaFam.ReadOnly = False
            txtNomZonaFam.BackColor = System.Drawing.SystemColors.Window
            txtInteriorFam.ReadOnly = False
            txtInteriorFam.BackColor = System.Drawing.SystemColors.Window
            btnBuscarUbigeoFam.Enabled = True
            txtReferenciaFam.ReadOnly = False
            txtReferenciaFam.BackColor = System.Drawing.SystemColors.Window
        ElseIf cbOtroDomicilio.Checked = False Then
            cmbTipoViaFam.ReadOnly = True
            cmbTipoViaFam.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoViaFam.Text = ""
            txtNomViaFam.ReadOnly = True
            txtNomViaFam.BackColor = System.Drawing.Color.PowderBlue
            txtNroViaFam.ReadOnly = True
            txtNroViaFam.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoZonaFam.ReadOnly = True
            cmbTipoZonaFam.BackColor = System.Drawing.Color.PowderBlue
            cmbTipoZonaFam.Text = ""
            txtNomZonaFam.ReadOnly = True
            txtNomZonaFam.BackColor = System.Drawing.Color.PowderBlue
            txtInteriorFam.ReadOnly = True
            txtInteriorFam.BackColor = System.Drawing.Color.PowderBlue
            btnBuscarUbigeoFam.Enabled = False
            txtReferenciaFam.ReadOnly = True
            txtReferenciaFam.BackColor = System.Drawing.Color.PowderBlue
        End If
    End Sub

    Private Sub ObtenerFamiliar()
        Try
            Dim registro As PersonaService.Familiares
            registro = oPersonaService.ObtenerFamiliares(toNumber(dgvFamiliares.CurrentRow.Cells("IdFamilia").Value))
            IdFamilia = registro.IdFamilia
            txtNomFam.Text = registro.Nombres
            txtApePatFam.Text = registro.ApePat
            txtApeMatFam.Text = registro.ApeMat
            txtFecNacFam.Value = registro.FecNac
            cmbTipoDocFam.Value = registro.TipoDocumentoId.CodDoc
            txtNumDocFam.Text = registro.NumDoc
            If registro.Sexo = 1 Then
                rbMasculinoF.Checked = True
                rbFemeninoF.Checked = False
            Else
                rbFemeninoF.Checked = True
                rbMasculinoF.Checked = False
            End If
            cmbVinculoFam.Value = registro.TipoVinculoFamilia.CodVinculo
            txtOcupacion.Text = registro.Ocupacion

            cbDerechoHab.Checked = registro.DerHabiente
            If registro.TipoDocPaternidad.CodDocPat <> "" Then
                cmbDocPat.Value = registro.TipoDocPaternidad.CodDocPat
            Else
                cmbDocPat.Text = ""
            End If
            txtNumDocPat.Text = registro.NumDocPat

            cbDerechoHabAct.Checked = registro.Activo
            If Not (registro.FecAlta.ToString = "") Then
                txtFechaAlta.IsNullDate = False
                txtFechaAlta.Value = CDate(registro.FecAlta)
                txtFechaAlta.Text = registro.FecAlta.ToString
            Else
                txtFechaAlta.IsNullDate = True
            End If

            If registro.TipoBajaHabiente.CodBaja <> "" Then
                cmbTipoBaja.Value = registro.TipoBajaHabiente.CodBaja
            Else
                cmbTipoBaja.Text = ""
            End If
            If Not (registro.FecBaja.ToString = "") Then
                txtFechaBaja.IsNullDate = False
                txtFechaBaja.Value = CDate(registro.FecBaja)
                txtFechaBaja.Text = registro.FecBaja.ToString
            Else
                txtFechaBaja.IsNullDate = True
            End If
            txtResDirIncHijoME.Text = registro.Resolucion

            cbOtroDomicilio.Checked = registro.OtroDomicilio
            cmbTipoViaFam.Value = registro.TipoVia.CodVia
            txtNomViaFam.Text = registro.NomVia
            txtNroViaFam.Text = registro.NumVia
            cmbTipoZonaFam.Value = registro.TipoZona.CodZona
            txtNomZonaFam.Text = registro.NomZona
            txtInteriorFam.Text = registro.Interior
            CodUbigeoFam = registro.Ubigeo.CodUbigeo
            txtUbigeoFam.Text = registro.Ubigeo.Departamento.NomDpto + " - " + registro.Ubigeo.Provincia.NomProv + " - " + registro.Ubigeo.Distrito.NomDist
            txtReferenciaFam.Text = registro.Referencia

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarFamiliar(ByVal registro As PersonaService.Familiares)
        Try
            Dim estado_process As Integer
            estado_process = oPersonaService.InsertarFamiliares(registro)
            type_process = "insert"
            If estado_process > 0 Then
                MsgBox("Se insertó el(la) Familiar Correctamente.")
                dtDatosFamiliares = Nothing
                ActualizarFamiliar()
                IdFamilia = estado_process
                RowPossFamiliares(dgvFamiliares, IdFamilia)
                edicionFamiliares = False
                ObtenerFamiliar()
                DesactivarFamiliar()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarFamiliar(ByVal registro As PersonaService.Familiares)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarFamiliares(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el(la) Familiar Correctamente.")
                dtDatosFamiliares = Nothing
                ActualizarFamiliar()
                RowPossFamiliares(dgvFamiliares, IdFamilia)
                edicionFamiliares = False
                ObtenerFamiliar()
                DesactivarFamiliar()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarFamiliar()
        Try
            Dim codigo As String = ""
            If dgvFamiliares.RowCount > 0 Then
                If IsDBNull(dgvFamiliares.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvFamiliares.CurrentRow.Cells("IdFamilia").Text
                End If
            End If
            dtDatosFamiliares = Nothing
            ListarFamiliares()
            If dgvFamiliares.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossFamiliares(dgvFamiliares, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES FAMILIARES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacerFam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerFam.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_familiar Then
                If dgvFamiliares.RowCount > 0 Then
                    edicionFamiliares = True
                    ObtenerFamiliar()
                    DesactivarFamiliar()
                Else
                    edicionFamiliares = False
                    DesactivarFamiliar()
                    LimpiarFamiliar()
                End If
                EnableOpcionesFamiliar()
            Else
                edicionFamiliares = True
                ObtenerFamiliar()
                DesactivarFamiliar()
            End If
        End If
    End Sub

    Private Function ValidaCamposFam() As Boolean
        Try     
            If toBlank(txtApePatFam.Text) = "" Then
                MsgBox("Debe Ingresar el Apellido Paterno.", MsgBoxStyle.Information, "Información")
                txtApePatFam.Focus()
                Return False
            ElseIf toBlank(txtApeMatFam.Text) = "" Then
                MsgBox("Debe Ingresar el Apellido Materno.", MsgBoxStyle.Information, "Información")
                txtApeMatFam.Focus()
                Return False
            ElseIf toBlank(txtNomFam.Text) = "" Then
                MsgBox("Debe Ingresar el(los) Nombre(s).", MsgBoxStyle.Information, "Información")
                txtNomFam.Focus()
                Return False
            ElseIf toBlank(cmbTipoDocFam.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDocFam.Focus()
                Return False
            ElseIf toBlank(cmbVinculoFam.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Vínculo Familiar.", MsgBoxStyle.Information, "Información")
                cmbVinculoFam.Focus()
                Return False
            ElseIf cbDerechoHab.Checked = True And toBlank(cmbDocPat.Value) = "" Then
                MsgBox("Debe Ingresar el Documento que acredita paternidad.", MsgBoxStyle.Information, "Información")
                cmbDocPat.Focus()
                Return False
            ElseIf toBlank(cmbDocPat.Text) <> "" And txtNumDocPat.Text = "" Then
                MsgBox("Debe Ingresar el número de documento que acredita paternidad.", MsgBoxStyle.Information, "Información")
                txtNumDocPat.Focus()
                Return False
            ElseIf cbDerechoHabAct.Checked = True And toBlank(txtFechaAlta.Value) = "" Then
                MsgBox("Debe Ingresar la fecha de alta.", MsgBoxStyle.Information, "Información")
                txtFechaAlta.Focus()
                Return False
            ElseIf cbDerechoHabAct.Checked = False And toBlank(cmbTipoBaja.Text) = "" Then
                MsgBox("Debe Ingresar el tipo de Baja.", MsgBoxStyle.Information, "Información")
                cmbTipoBaja.Focus()
                Return False
            ElseIf cbDerechoHabAct.Checked = False And toBlank(txtFechaBaja.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de baja.", MsgBoxStyle.Information, "Información")
                txtFechaBaja.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtUbigeoFam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbigeoFam.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarUbigeoFam.Enabled = True Then
                e.Handled = True
                btnBuscarUbigeoFam_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarUbigeoFam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarUbigeoFam.Click
        Try
            Dim frm As New frmBuscarUbigeo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                CodUbigeoFam = frm.CodUbigeo
                txtUbigeoFam.Text = frm.Nombre
            End If
            txtUbigeoFam.Select()
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR UBIGEO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGrabarFam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarFam.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim registro As New PersonaService.Familiares
                Dim Persona As New PersonaService.Persona
                Dim TipoBajaHabiente As New PersonaService.TipoBajaHabiente
                Dim TipoDocPaternidad As New PersonaService.TipoDocPaternidad
                Dim TipoDocumento As New PersonaService.TipoDocumentoId
                Dim TipoVia As New PersonaService.TipoVia
                Dim TipoVinculoFamilia As New PersonaService.TipoVinculoFamilia
                Dim TipoZona As New PersonaService.TipoZona
                Dim Ubigeo As New PersonaService.Ubigeo

                registro.IdFamilia = IdFamilia
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                registro.Nombres = txtNomFam.Text
                registro.ApePat = txtApePatFam.Text
                registro.ApeMat = txtApeMatFam.Text
                registro.FecNac = txtFecNacFam.Value
                TipoDocumento.CodDoc = cmbTipoDocFam.Value
                registro.TipoDocumentoId = TipoDocumento
                registro.NumDoc = txtNumDocFam.Text
                If rbMasculinoF.Checked = True Then
                    registro.Sexo = 1
                ElseIf rbFemeninoF.Checked = True Then
                    registro.Sexo = 2
                End If
                TipoVinculoFamilia.CodVinculo = cmbVinculoFam.Value
                registro.TipoVinculoFamilia = TipoVinculoFamilia
                registro.Ocupacion = txtOcupacion.Text

                registro.DerHabiente = cbDerechoHab.Checked
                TipoDocPaternidad.CodDocPat = IIf(cmbDocPat.Text <> "", cmbDocPat.Value, Nothing)
                registro.TipoDocPaternidad = TipoDocPaternidad
                registro.NumDocPat = IIf(txtNumDocPat.Text <> "", txtNumDocPat.Text, Nothing)

                registro.Activo = cbDerechoHabAct.Checked
                registro.FecAlta = IIf(txtFechaAlta.Text = "", Nothing, txtFechaAlta.Value)
                TipoBajaHabiente.CodBaja = IIf(cmbTipoBaja.Text <> "", cmbTipoBaja.Value, Nothing)
                registro.TipoBajaHabiente = TipoBajaHabiente
                registro.FecBaja = IIf(txtFechaBaja.Text = "", Nothing, txtFechaBaja.Value)
                registro.Resolucion = IIf(txtResDirIncHijoME.Text <> "", txtResDirIncHijoME.Text, Nothing)

                registro.OtroDomicilio = cbOtroDomicilio.Checked
                TipoVia.CodVia = cmbTipoViaFam.Value
                registro.TipoVia = TipoVia
                registro.NomVia = txtNomViaFam.Text
                registro.NumVia = txtNroViaFam.Text
                TipoZona.CodZona = cmbTipoZonaFam.Value
                registro.TipoZona = TipoZona
                registro.NomZona = txtNomZonaFam.Text
                registro.Interior = txtInteriorFam.Text
                Ubigeo.CodUbigeo = IIf(CodUbigeoFam = "", Nothing, CodUbigeoFam)
                registro.Ubigeo = Ubigeo
                registro.Referencia = txtReferenciaFam.Text

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.NomPc = Session.sNomPc

                If state_familiar = False Then
                    InsertarFamiliar(registro)
                Else
                    ModificarFamiliar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL(LA) FAMILIAR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditFam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditFam.Click
        state_familiar = True
        ActivarFamiliar()
        ObtenerFamiliar()
    End Sub

    Private Sub miNuevoFam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoFam.Click
        state_familiar = False
        LimpiarFamiliar()
        ActivarFamiliar()
    End Sub

    Private Sub miElimFam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimFam.Click
        Try
            cmOpFamiliar.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPersonaService.BorrarFamiliares(toNumber(dgvFamiliares.CurrentRow.Cells("IdFamilia").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatosFamiliares = Nothing
                    ListarFamiliares()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL FAMILIAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActFam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActFam.Click
        ActualizarFamiliar()
    End Sub

    Private Function ValidaCodigoFamiliar() As Boolean
        Try
            If dgvFamiliares.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvFamiliares.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvFamiliares.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvFamiliar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFamiliares.SelectionChanged
        If dgvFamiliares.RowCount > 0 Then
            If ValidaCodigoFamiliar() Then
                ObtenerFamiliar()
                EnableOpcionesFamiliar()
            End If
        Else
            LimpiarFamiliar()
            DesactivarFamiliar()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////// ESTUDIOS REALIZADOS //////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    Private Sub Estudios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbNivelEst.KeyPress _
          , txtInstitucionEst.KeyPress _
          , txtCarreraEst.KeyPress _
          , txtFecInicioEst.KeyPress _
          , txtFecFinalEst.KeyPress _
          , txtObsEst.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ListarEstudios()
        Try
            dtDatosEstudios = oCapacitacionService.MostrarEstudioRealizado(IdPersona).Tables(0)
            dgvEstudios.DataSource = dtDatosEstudios
            EnableOpcionesEstudio()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR ESTUDIOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossEstudios(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdEstudio").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS ESTUDIO]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesEstudio()
        Try
            If dgvEstudios.RowCount > 0 Then
                miElimEst.Enabled = True
                miEditEst.Enabled = True
            Else
                miElimEst.Enabled = False
                miEditEst.Enabled = False
            End If
            biGrabarEstudios.Enabled = edicionEstudio
            biDeshacerEstudios.Enabled = edicionEstudio

            dgvEstudios.Enabled = IIf(Not edicionEstudio, True, False)
            cmOpEstudios.Enabled = IIf(Not edicionEstudio, True, False)

            tpFichaGeneral.Enabled = IIf(edicionEstudio = False, True, False)
            tpIdioma.Enabled = IIf(edicionEstudio = False, True, False)
            tpInformatica.Enabled = IIf(edicionEstudio = False, True, False)
            tpfamiliares.Enabled = IIf(edicionEstudio = False, True, False)
            tpExpLaboral.Enabled = IIf(edicionEstudio = False, True, False)
            'tpCapacitaciones.Enabled = IIf(edicionEstudio = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES ESTUDIOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarEstudio()
        Try
            cmbNivelEst.Text = ""
            txtInstitucionEst.Text = ""
            txtCarreraEst.Text = ""
            txtFecInicioEst.IsNullDate = True
            txtFecFinalEst.IsNullDate = True
            txtObsEst.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarEstudio()
        Try
            'LimpiarEstudio()
            cmbNivelEst.ReadOnly = True
            cmbNivelEst.BackColor = System.Drawing.Color.PowderBlue
            txtInstitucionEst.ReadOnly = True
            txtInstitucionEst.BackColor = System.Drawing.Color.PowderBlue
            txtCarreraEst.ReadOnly = True
            txtCarreraEst.BackColor = System.Drawing.Color.PowderBlue
            txtFecInicioEst.ReadOnly = True
            txtFecInicioEst.BackColor = System.Drawing.Color.PowderBlue
            txtFecFinalEst.ReadOnly = True
            txtFecFinalEst.BackColor = System.Drawing.Color.PowderBlue
            txtObsEst.ReadOnly = True
            txtObsEst.BackColor = System.Drawing.Color.PowderBlue
            edicionEstudio = False
            EnableOpcionesEstudio()
            dgvEstudios.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActivarEstudio()
        Try
            cmbNivelEst.ReadOnly = False
            cmbNivelEst.BackColor = System.Drawing.SystemColors.Window
            cmbNivelEst.SelectedIndex = 0
            txtInstitucionEst.ReadOnly = False
            txtInstitucionEst.BackColor = System.Drawing.SystemColors.Window
            txtCarreraEst.ReadOnly = False
            txtCarreraEst.BackColor = System.Drawing.SystemColors.Window
            txtFecInicioEst.ReadOnly = False
            txtFecInicioEst.BackColor = System.Drawing.SystemColors.Window
            txtFecInicioEst.IsNullDate = False
            txtFecInicioEst.Value = Today
            txtFecFinalEst.ReadOnly = False
            txtFecFinalEst.BackColor = System.Drawing.SystemColors.Window
            txtFecFinalEst.IsNullDate = False
            txtFecFinalEst.Value = Today
            txtObsEst.ReadOnly = False
            txtObsEst.BackColor = System.Drawing.SystemColors.Window
            edicionEstudio = True
            EnableOpcionesEstudio()
            cmbNivelEst.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerEstudio()
        Try
            Dim registro As CapacitacionService.EstudioRealizado
            registro = oCapacitacionService.ObtenerEstudioRealizado(toNumber(dgvEstudios.CurrentRow.Cells("IdEstudio").Value))
            IdEstudio = registro.IdEstudio
            cmbNivelEst.Value = registro.NivelEducativo.CodNivel
            txtInstitucionEst.Text = registro.Institucion
            txtCarreraEst.Text = registro.Carrera
            If Not (registro.FecInicio.ToString = "") Then
                txtFecInicioEst.IsNullDate = False
                txtFecInicioEst.Value = CDate(registro.FecInicio)
                txtFecInicioEst.Text = registro.FecInicio.ToString
            Else
                txtFecInicioEst.IsNullDate = True
            End If
            If Not (registro.FecFinal.ToString = "") Then
                txtFecFinalEst.IsNullDate = False
                txtFecFinalEst.Value = CDate(registro.FecFinal)
                txtFecFinalEst.Text = registro.FecFinal.ToString
            Else
                txtFecFinalEst.IsNullDate = True
            End If
            txtObsEst.Text = registro.Observacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarEstudio(ByVal registro As CapacitacionService.EstudioRealizado)
        Try
            Dim estado_process As Integer
            estado_process = oCapacitacionService.InsertarEstudioRealizado(registro)
            type_process = "insert"
            If estado_process > 0 Then                
                MsgBox("Se insertó el Estudio Correctamente.")
                dtDatosEstudios = Nothing
                ActualizarEstudio()
                IdEstudio = estado_process
                RowPossEstudios(dgvEstudios, IdEstudio)
                edicionEstudio = False
                ObtenerEstudio()
                DesactivarEstudio()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarEstudio(ByVal registro As CapacitacionService.EstudioRealizado)
        Try
            Dim estado_process As Boolean
            estado_process = oCapacitacionService.ActualizarEstudioRealizado(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Estudio Correctamente.")
                dtDatosEstudios = Nothing
                ActualizarEstudio()
                RowPossEstudios(dgvEstudios, IdEstudio)
                edicionEstudio = False
                ObtenerEstudio()
                DesactivarEstudio()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarEstudio()
        Try
            Dim codigo As String = ""
            If dgvEstudios.RowCount > 0 Then
                If IsDBNull(dgvEstudios.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvEstudios.CurrentRow.Cells("IdEstudio").Text
                End If
            End If
            dtDatosEstudios = Nothing
            ListarEstudios()
            If dgvEstudios.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossEstudios(dgvEstudios, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacerEstudios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerEstudios.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_estudio Then
                If dgvEstudios.RowCount > 0 Then
                    edicionEstudio = True
                    ObtenerEstudio()
                    DesactivarEstudio()
                Else
                    edicionEstudio = False
                    DesactivarEstudio()
                    LimpiarEstudio()
                End If
                EnableOpcionesEstudio()
            Else
                edicionEstudio = True
                ObtenerEstudio()
                DesactivarEstudio()
            End If
        End If
    End Sub

    Private Sub biGrabarEstudios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarEstudios.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim registro As New CapacitacionService.EstudioRealizado
                Dim Persona As New CapacitacionService.Persona
                Dim NivelEducativo As New CapacitacionService.NivelEducativo

                registro.IdEstudio = IdEstudio
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                NivelEducativo.CodNivel = cmbNivelEst.Value
                registro.NivelEducativo = NivelEducativo
                registro.Institucion = txtInstitucionEst.Text
                registro.Carrera = txtCarreraEst.Text
                registro.FecInicio = txtFecInicioEst.Value
                registro.FecFinal = IIf(txtFecFinalEst.Text = "", Nothing, txtFecFinalEst.Value)
                registro.Observacion = txtObsEst.Text

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.NomPc = Session.sNomPc

                If state_estudio = False Then
                    InsertarEstudio(registro)
                Else
                    ModificarEstudio(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL ESTUDIO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditEst.Click
        state_estudio = True
        ActivarEstudio()
        ObtenerEstudio()
    End Sub

    Private Sub miNuevoEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoEst.Click
        state_estudio = False
        LimpiarEstudio()
        ActivarEstudio()
    End Sub

    Private Sub miElimEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimEst.Click
        Try
            cmOpEstudios.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCapacitacionService.BorrarEstudioRealizado(toNumber(dgvEstudios.CurrentRow.Cells("IdEstudio").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatosEstudios = Nothing
                    ListarEstudios()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL ESTUDIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActEst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActEst.Click
        ActualizarEstudio()
    End Sub

    Private Function ValidaCodigoEstudio() As Boolean
        Try
            If dgvEstudios.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvEstudios.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvEstudios.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvEstudios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEstudios.SelectionChanged
        If dgvEstudios.RowCount > 0 Then
            If ValidaCodigoEstudio() Then
                ObtenerEstudio()
                EnableOpcionesEstudio()
            End If
        Else
            LimpiarEstudio()
            DesactivarEstudio()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////////////////// IDIOMA ////////////////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    Private Sub Idioma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbIdioma.KeyPress _
          , cmbNivelIdioma.KeyPress _
          , cbEscrito.KeyPress _
          , cbHablado.KeyPress _
          , txtObsIdioma.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ListarIdiomas()
        Try
            dtDatosIdioma = oPersonaService.FiltrarIdioma(IdPersona).Tables(0)
            dgvIdioma.DataSource = dtDatosIdioma
            EnableOpcionesIdioma()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR IDIOMAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossIdioma(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdIdioma").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS IDIOMA]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesIdioma()
        Try
            If dgvIdioma.RowCount > 0 Then
                miElimIdioma.Enabled = True
                miEditIdioma.Enabled = True
            Else
                miElimIdioma.Enabled = False
                miEditIdioma.Enabled = False
            End If
            biGrabarIdioma.Enabled = edicionIdioma
            biDeshacerIdioma.Enabled = edicionIdioma

            dgvIdioma.Enabled = IIf(Not edicionIdioma, True, False)
            cmOpIdiomas.Enabled = IIf(Not edicionIdioma, True, False)

            tpFichaGeneral.Enabled = IIf(edicionIdioma = False, True, False)
            tpInformatica.Enabled = IIf(edicionIdioma = False, True, False)
            tpfamiliares.Enabled = IIf(edicionIdioma = False, True, False)
            tpExpLaboral.Enabled = IIf(edicionIdioma = False, True, False)
            'tpCapacitaciones.Enabled = IIf(edicionIdioma = False, True, False)
            gbEstudios.Enabled = IIf(edicionIdioma = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarIdioma()
        Try
            cmbIdioma.Text = ""
            cmbNivelIdioma.Text = ""
            cbHablado.Checked = False
            cbEscrito.Checked = False
            txtObsIdioma.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarIdioma()
        Try
            'LimpiarIdioma()
            cmbIdioma.ReadOnly = True
            cmbIdioma.BackColor = System.Drawing.Color.PowderBlue
            cmbNivelIdioma.ReadOnly = True
            cmbNivelIdioma.BackColor = System.Drawing.Color.PowderBlue
            cbEscrito.Enabled = False
            cbHablado.Enabled = False
            txtObsIdioma.ReadOnly = True
            txtObsIdioma.BackColor = System.Drawing.Color.PowderBlue
            edicionIdioma = False
            EnableOpcionesIdioma()
            dgvIdioma.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActivarIdioma()
        Try
            cmbIdioma.ReadOnly = False
            cmbIdioma.BackColor = System.Drawing.SystemColors.Window
            cmbIdioma.SelectedIndex = 0
            cmbNivelIdioma.ReadOnly = False
            cmbNivelIdioma.BackColor = System.Drawing.SystemColors.Window
            cmbNivelIdioma.SelectedIndex = 0
            cbEscrito.Enabled = True
            cbHablado.Enabled = True
            txtObsIdioma.ReadOnly = False
            txtObsIdioma.BackColor = System.Drawing.SystemColors.Window
            edicionIdioma = True
            EnableOpcionesIdioma()
            cmbIdioma.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerIdioma()
        Try
            Dim registro As PersonaService.Idiomas
            registro = oPersonaService.ObtenerIdioma(toNumber(dgvIdioma.CurrentRow.Cells("IdIdioma").Value))
            IdIdioma = registro.IdIdioma
            cmbIdioma.Value = registro.DesIdioma
            cmbNivelIdioma.Value = registro.Nivel
            cbEscrito.Checked = registro.Escrito
            cbHablado.Checked = registro.Hablado
            txtObsIdioma.Text = registro.Observacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarIdioma(ByVal registro As PersonaService.Idiomas)
        Try
            Dim estado_process As Integer
            estado_process = oPersonaService.InsertarIdioma(registro)
            type_process = "insert"
            If estado_process > 0 Then                
                MsgBox("Se insertó el Idioma Correctamente.")
                dtDatosIdioma = Nothing
                ActualizarIdioma()
                IdIdioma = estado_process
                RowPossIdioma(dgvIdioma, IdIdioma)
                edicionIdioma = False
                ObtenerIdioma()
                DesactivarIdioma()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarIdioma(ByVal registro As PersonaService.Idiomas)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarIdioma(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Idioma Correctamente.")
                dtDatosIdioma = Nothing
                ActualizarIdioma()
                RowPossIdioma(dgvIdioma, IdIdioma)
                edicionIdioma = False
                ObtenerIdioma()
                DesactivarIdioma()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarIdioma()
        Try
            Dim codigo As String = ""
            If dgvIdioma.RowCount > 0 Then
                If IsDBNull(dgvIdioma.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvIdioma.CurrentRow.Cells("IdIdioma").Text
                End If
            End If
            dtDatosIdioma = Nothing
            ListarIdiomas()
            If dgvIdioma.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossIdioma(dgvIdioma, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacerIdioma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerIdioma.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_idioma Then
                If dgvIdioma.RowCount > 0 Then
                    edicionIdioma = True
                    ObtenerIdioma()
                    DesactivarIdioma()
                Else
                    edicionIdioma = False
                    DesactivarIdioma()
                    LimpiarIdioma()
                End If
                EnableOpcionesIdioma()
            Else
                edicionIdioma = True
                ObtenerIdioma()
                DesactivarIdioma()
            End If
        End If
    End Sub

    Private Sub biGrabarIdioma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarIdioma.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim registro As New PersonaService.Idiomas
                Dim Persona As New PersonaService.Persona

                registro.IdIdioma = IdIdioma
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                registro.DesIdioma = cmbIdioma.Text
                registro.Nivel = cmbNivelIdioma.Text
                registro.Escrito = cbEscrito.Checked
                registro.Hablado = cbHablado.Checked
                registro.Observacion = txtObsIdioma.Text

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.NomPc = Session.sNomPc

                If state_idioma = False Then
                    InsertarIdioma(registro)
                Else
                    ModificarIdioma(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL IDIOMA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditIdioma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditIdioma.Click
        state_idioma = True
        ActivarIdioma()
        ObtenerIdioma()
    End Sub

    Private Sub miNuevoIdioma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoIdioma.Click
        state_idioma = False
        LimpiarIdioma()
        ActivarIdioma()
    End Sub

    Private Sub miElimIdioma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimIdioma.Click
        Try
            cmOpIdiomas.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPersonaService.BorrarIdioma(toNumber(dgvIdioma.CurrentRow.Cells("IdIdioma").Value))
                If estado_process = True Then
                    dtDatosIdioma = Nothing
                    ListarIdiomas()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL IDIOMA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActIdioma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActIdioma.Click
        ActualizarIdioma()
    End Sub

    Private Function ValidaCodigoIdioma() As Boolean
        Try
            If dgvIdioma.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvIdioma.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvIdioma.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvIdioma_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvIdioma.SelectionChanged
        If dgvIdioma.RowCount > 0 Then
            If ValidaCodigoIdioma() Then
                EnableOpcionesIdioma()
                ObtenerIdioma()
            End If
        Else
            LimpiarIdioma()
            DesactivarIdioma()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '//////////////////////////////////////////////////////////////////////////// INFORMATICA /////////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    Private Sub Informatica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbPrograma.KeyPress _
          , cmbNivelInfor.KeyPress _
          , txtObsInformatica.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ListarInformaticas()
        Try
            dtDatosInformatica = oPersonaService.FiltrarInformatica(IdPersona).Tables(0)
            dgvInformatica.DataSource = dtDatosInformatica
            EnableOpcionesInformatica()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR INFORMÁTICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub RowPossInformatica(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdInformatica").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS INFORMATICA]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesInformatica()
        Try
            If dgvInformatica.RowCount > 0 Then
                miElimInformatica.Enabled = True
                miEditInformatica.Enabled = True
            Else
                miElimInformatica.Enabled = False
                miEditInformatica.Enabled = False
            End If
            biGrabarInformatica.Enabled = edicionInformatica
            biDeshacerInformatica.Enabled = edicionInformatica

            dgvInformatica.Enabled = IIf(Not edicionInformatica, True, False)
            cmOpInformatica.Enabled = IIf(Not edicionInformatica, True, False)

            tpFichaGeneral.Enabled = IIf(edicionInformatica = False, True, False)
            tpIdioma.Enabled = IIf(edicionInformatica = False, True, False)
            tpfamiliares.Enabled = IIf(edicionInformatica = False, True, False)
            tpExpLaboral.Enabled = IIf(edicionInformatica = False, True, False)
            'tpCapacitaciones.Enabled = IIf(edicionInformatica = False, True, False)
            gbEstudios.Enabled = IIf(edicionInformatica = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub LimpiarInformatica()
        Try
            cmbPrograma.Text = ""
            cmbNivelInfor.Text = ""
            txtObsInformatica.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarInformatica()
        Try
            'LimpiarInformatica()
            cmbPrograma.ReadOnly = True
            cmbPrograma.BackColor = System.Drawing.Color.PowderBlue
            cmbNivelInfor.ReadOnly = True
            cmbNivelInfor.BackColor = System.Drawing.Color.PowderBlue
            txtObsInformatica.ReadOnly = True
            txtObsInformatica.BackColor = System.Drawing.Color.PowderBlue
            edicionInformatica = False
            EnableOpcionesInformatica()
            dgvInformatica.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub ActivarInformatica()
        Try
            cmbPrograma.ReadOnly = False
            cmbPrograma.BackColor = System.Drawing.SystemColors.Window
            cmbPrograma.SelectedIndex = 0
            cmbNivelInfor.ReadOnly = False
            cmbNivelInfor.BackColor = System.Drawing.SystemColors.Window
            cmbNivelInfor.SelectedIndex = 0
            txtObsInformatica.ReadOnly = False
            txtObsInformatica.BackColor = System.Drawing.SystemColors.Window
            edicionInformatica = True
            EnableOpcionesInformatica()
            cmbPrograma.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerInformatica()
        Try
            Dim registro As PersonaService.Informatica
            registro = oPersonaService.ObtenerInformatica(toNumber(dgvInformatica.CurrentRow.Cells("IdInformatica").Value))
            IdInformatica = registro.IdInformatica
            cmbPrograma.Value = registro.ProgramaInformatica.IdPrograma
            cmbNivelInfor.Value = registro.Nivel
            txtObsInformatica.Text = registro.Observacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarInformatica(ByVal registro As PersonaService.Informatica)
        Try
            Dim estado_process As Integer
            estado_process = oPersonaService.InsertarInformatica(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdInformatica = estado_process
                MsgBox("Se insertó el Informática Correctamente.")
                dtDatosInformatica = Nothing
                ListarInformaticas()
                RowPossInformatica(dgvInformatica, IdInformatica)
                edicionInformatica = False
                DesactivarInformatica()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarInformatica(ByVal registro As PersonaService.Informatica)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarInformatica(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Informática Correctamente.")
                dtDatosInformatica = Nothing
                ListarInformaticas()
                RowPossInformatica(dgvInformatica, IdInformatica)
                edicionInformatica = False
                DesactivarInformatica()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarInformatica()
        Try
            Dim codigo As String = ""
            If dgvInformatica.RowCount > 0 Then
                If IsDBNull(dgvInformatica.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvInformatica.CurrentRow.Cells("IdInformatica").Text
                End If
            End If
            dtDatosInformatica = Nothing
            ListarInformaticas()
            If dgvInformatica.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossInformatica(dgvInformatica, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacerInformatica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerInformatica.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_informatica Then
                If dgvInformatica.RowCount > 0 Then
                    edicionInformatica = True
                    ObtenerInformatica()
                    DesactivarInformatica()
                Else
                    edicionInformatica = False
                    DesactivarInformatica()
                    LimpiarInformatica()
                End If
                EnableOpcionesInformatica()
            Else
                edicionInformatica = True
                ObtenerInformatica()
                DesactivarInformatica()
            End If
        End If
    End Sub

    Private Sub biGrabarInformatica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarInformatica.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim registro As New PersonaService.Informatica
                Dim Persona As New PersonaService.Persona
                Dim Programa As New PersonaService.ProgramaInformatica

                registro.IdInformatica = IdInformatica
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                Programa.IdPrograma = cmbPrograma.Value
                registro.ProgramaInformatica = Programa
                registro.Nivel = cmbNivelIdioma.Value
                registro.Observacion = txtObsInformatica.Text

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.NomPc = Session.sNomPc

                If state_informatica = False Then
                    InsertarInformatica(registro)
                Else
                    ModificarInformatica(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR INFORMATICA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditInformatica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditInformatica.Click
        state_informatica = True
        ActivarInformatica()
        ObtenerInformatica()
    End Sub

    Private Sub miNuevoInformatica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoInformatica.Click
        state_informatica = False
        LimpiarInformatica()
        ActivarInformatica()
    End Sub

    Private Sub miElimInformatica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimInformatica.Click
        Try
            cmOpInformatica.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPersonaService.BorrarInformatica(toNumber(dgvInformatica.CurrentRow.Cells("IdInformatica").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatosInformatica = Nothing
                    ListarInformaticas()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR INFORMATICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActInformatica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActInformatica.Click
        ActualizarInformatica()
    End Sub

    Private Function ValidaCodigoInformatica() As Boolean
        Try
            If dgvInformatica.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvInformatica.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvInformatica.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvInformatica_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInformatica.SelectionChanged
        If dgvInformatica.RowCount > 0 Then
            If ValidaCodigoInformatica() Then
                ObtenerInformatica()
                EnableOpcionesInformatica()
            End If
        Else
            LimpiarInformatica()
            DesactivarInformatica()
        End If
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////////////// EXP. LABORAL ////////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    Private Sub ExpLaboral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                    txtEmpresaExp.KeyPress _
                  , txtCargoExp.KeyPress _
                  , txtFecInicioExpLab.KeyPress _
                  , txtFecTerminoExpLab.KeyPress _
                  , txtSueldoExpLab.KeyPress _
                  , cmbMonExpLab.KeyPress _
                  , txtMotivoRetiroExpLab.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ListarExpLaboral()
        Try
            dtDatosExpLaboral = oPersonaService.FiltrarExperienciaLaboral(IdPersona).Tables(0)
            dgvExpLaboral.DataSource = dtDatosExpLaboral
            EnableOpcionesExpLaboral()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR IDIOMAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossExpLaboral(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdExperiencia").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS EXP LABORAL]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesExpLaboral()
        Try
            If dgvExpLaboral.RowCount > 0 Then
                miElimExpLab.Enabled = True
                miEditExpLab.Enabled = True
            Else
                miElimExpLab.Enabled = False
                miEditExpLab.Enabled = False
            End If
            biGrabarExpLab.Enabled = edicionExpLaboral
            biDeshacerExpLab.Enabled = edicionExpLaboral

            dgvExpLaboral.Enabled = IIf(Not edicionExpLaboral, True, False)
            cmOpExpLab.Enabled = IIf(Not edicionExpLaboral, True, False)

            tpFichaGeneral.Enabled = IIf(edicionExpLaboral = False, True, False)
            tpfamiliares.Enabled = IIf(edicionExpLaboral = False, True, False)
            tpInstruccion.Enabled = IIf(edicionExpLaboral = False, True, False)
            'tpCapacitaciones.Enabled = IIf(edicionExpLaboral = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarExpLaboral()
        Try
            txtEmpresaExp.Text = ""
            txtCargoExp.Text = ""
            txtFecInicioExpLab.IsNullDate = True
            txtFecTerminoExpLab.IsNullDate = True
            txtSueldoExpLab.Value = 0
            cmbMonExpLab.Text = ""
            txtMotivoRetiroExpLab.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarExpLaboral()
        Try
            'LimpiarExpLaboral()
            txtEmpresaExp.ReadOnly = True
            txtEmpresaExp.BackColor = System.Drawing.Color.PowderBlue
            txtCargoExp.ReadOnly = True
            txtCargoExp.BackColor = System.Drawing.Color.PowderBlue
            txtFecInicioExpLab.ReadOnly = True
            txtFecInicioExpLab.BackColor = System.Drawing.Color.PowderBlue
            txtFecTerminoExpLab.ReadOnly = True
            txtFecTerminoExpLab.BackColor = System.Drawing.Color.PowderBlue
            txtSueldoExpLab.ReadOnly = True
            txtSueldoExpLab.BackColor = System.Drawing.Color.PowderBlue
            cmbMonExpLab.ReadOnly = True
            cmbMonExpLab.BackColor = System.Drawing.Color.PowderBlue
            txtMotivoRetiroExpLab.ReadOnly = True
            txtMotivoRetiroExpLab.BackColor = System.Drawing.Color.PowderBlue
            edicionExpLaboral = False
            EnableOpcionesExpLaboral()
            dgvExpLaboral.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActivarExpLaboral()
        Try
            txtEmpresaExp.ReadOnly = False
            txtEmpresaExp.BackColor = System.Drawing.SystemColors.Window
            txtCargoExp.ReadOnly = False
            txtCargoExp.BackColor = System.Drawing.SystemColors.Window
            txtFecInicioExpLab.ReadOnly = False
            txtFecInicioExpLab.BackColor = System.Drawing.SystemColors.Window
            txtFecInicioExpLab.IsNullDate = False
            txtFecInicioExpLab.Value = Today            
            txtFecTerminoExpLab.ReadOnly = False
            txtFecTerminoExpLab.BackColor = System.Drawing.SystemColors.Window
            txtSueldoExpLab.ReadOnly = False
            txtSueldoExpLab.BackColor = System.Drawing.SystemColors.Window
            cmbMonExpLab.ReadOnly = False
            cmbMonExpLab.BackColor = System.Drawing.SystemColors.Window
            cmbMonExpLab.Value = "NS"
            txtMotivoRetiroExpLab.ReadOnly = False
            txtMotivoRetiroExpLab.BackColor = System.Drawing.SystemColors.Window
            edicionExpLaboral = True
            EnableOpcionesExpLaboral()
            txtEmpresaExp.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerExpLaboral()
        Try
            Dim registro As PersonaService.ExperienciaLaboral
            registro = oPersonaService.ObtenerExperienciaLaboral(toNumber(dgvExpLaboral.CurrentRow.Cells("IdExperiencia").Value))
            IdExperiencia = registro.IdExperiencia
            txtEmpresaExp.Text = registro.Empresa
            txtCargoExp.Text = registro.Cargo
            If Not (registro.FecIngreso.ToString = "") Then
                txtFecInicioExpLab.IsNullDate = False
                txtFecInicioExpLab.Value = CDate(registro.FecIngreso)
                txtFecInicioExpLab.Text = registro.FecIngreso.ToString
            Else
                txtFecInicioExpLab.IsNullDate = True
            End If
            If Not (registro.FecSalida.ToString = "") Then
                txtFecTerminoExpLab.IsNullDate = False
                txtFecTerminoExpLab.Value = CDate(registro.FecSalida)
                txtFecTerminoExpLab.Text = registro.FecSalida.ToString
            Else
                txtFecTerminoExpLab.IsNullDate = True
            End If
            txtSueldoExpLab.Value = registro.Sueldo
            cmbMonExpLab.Value = registro.Moneda.CodMon
            txtMotivoRetiroExpLab.Text = registro.MotivoRetiro
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarExpLaboral(ByVal registro As PersonaService.ExperienciaLaboral)
        Try
            Dim estado_process As Integer
            estado_process = oPersonaService.InsertarExperienciaLaboral(registro)
            type_process = "insert"
            If estado_process > 0 Then                
                MsgBox("Se insertó la Exp. Laboral Correctamente.")
                dtDatosExpLaboral = Nothing
                ActualizarExpLaboral()
                IdExperiencia = estado_process
                RowPossExpLaboral(dgvExpLaboral, IdExperiencia)
                edicionExpLaboral = False
                ObtenerExpLaboral()
                DesactivarExpLaboral()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarExpLaboral(ByVal registro As PersonaService.ExperienciaLaboral)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarExperienciaLaboral(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Exp. Laboral Correctamente.")
                dtDatosExpLaboral = Nothing
                ActualizarExpLaboral()
                RowPossExpLaboral(dgvExpLaboral, IdExperiencia)
                edicionExpLaboral = False
                ObtenerExpLaboral()
                DesactivarExpLaboral()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarExpLaboral()
        Try
            Dim codigo As String = ""
            If dgvExpLaboral.RowCount > 0 Then
                If IsDBNull(dgvExpLaboral.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvExpLaboral.CurrentRow.Cells("IdExperiencia").Text
                End If
            End If
            dtDatosExpLaboral = Nothing
            ListarExpLaboral()
            If dgvExpLaboral.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossExpLaboral(dgvExpLaboral, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES EXP. LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCamposExpLab() As Boolean
        Try
            If toBlank(txtEmpresaExp.Text) = "" Then
                MsgBox("Debe Ingresar el nombre de la Empresa.", MsgBoxStyle.Information, "Información")
                txtEmpresaExp.Focus()
                Return False
            ElseIf toBlank(txtCargoExp.Text) = "" Then
                MsgBox("Debe Ingresar el Cargo.", MsgBoxStyle.Information, "Información")
                txtCargoExp.Focus()
                Return False
            ElseIf toBlank(txtFecInicioExpLab.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Inicio.", MsgBoxStyle.Information, "Información")
                txtFecInicioExpLab.Focus()
                Return False
            ElseIf toDouble(txtSueldoExpLab.Value) = 0 Then
                MsgBox("Debe Ingresar el Sueldo.", MsgBoxStyle.Information, "Información")
                txtSueldoExpLab.Focus()
                Return False
            ElseIf toBlank(cmbMonExpLab.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMonExpLab.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biDeshacerExpLab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerExpLab.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_explaboral Then
                If dgvExpLaboral.RowCount > 0 Then
                    edicionExpLaboral = True
                    ObtenerExpLaboral()
                    DesactivarExpLaboral()
                Else
                    edicionExpLaboral = False
                    DesactivarExpLaboral()
                    LimpiarExpLaboral()
                End If
                EnableOpcionesExpLaboral()
            Else
                edicionExpLaboral = True
                ObtenerExpLaboral()
                DesactivarExpLaboral()
            End If
        End If
    End Sub

    Private Sub biGrabarExpLab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarExpLab.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCamposExpLab() Then
                    Dim registro As New PersonaService.ExperienciaLaboral
                    Dim Persona As New PersonaService.Persona
                    Dim Moneda As New PersonaService.Moneda

                    registro.IdExperiencia = IdExperiencia
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.Empresa = txtEmpresaExp.Text
                    registro.Cargo = txtCargoExp.Text
                    registro.FecIngreso = txtFecInicioExpLab.Value
                    registro.FecSalida = IIf(txtFecTerminoExpLab.Text = "", Nothing, txtFecTerminoExpLab.Value)
                    registro.Sueldo = toDouble(txtSueldoExpLab.Value)
                    Moneda.CodMon = cmbMonExpLab.Value
                    registro.Moneda = Moneda
                    registro.MotivoRetiro = txtMotivoRetiroExpLab.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.FecReg = Today
                    registro.NomPc = Session.sNomPc

                    If state_explaboral = False Then
                        InsertarExpLaboral(registro)
                    Else
                        ModificarExpLaboral(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EXP. LABORAL:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditExpLab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditExpLab.Click
        state_explaboral = True
        ActivarExpLaboral()
        ObtenerExpLaboral()
    End Sub

    Private Sub miNuevoExpLab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoExpLab.Click
        state_explaboral = False
        LimpiarExpLaboral()
        ActivarExpLaboral()
    End Sub

    Private Sub miElimExpLab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimExpLab.Click
        Try
            cmOpExpLab.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPersonaService.BorrarExperienciaLaboral(toNumber(dgvExpLaboral.CurrentRow.Cells("IdExperiencia").Value))
                If estado_process = True Then
                    dtDatosExpLaboral = Nothing
                    ListarExpLaboral()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EXP LABORAL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActExpLab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActExpLab.Click
        ActualizarExpLaboral()
    End Sub

    Private Function ValidaCodigoExpLab() As Boolean
        Try
            If dgvExpLaboral.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvExpLaboral.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvExpLaboral.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvExpLaboral_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvExpLaboral.SelectionChanged
        If dgvExpLaboral.RowCount > 0 Then
            If ValidaCodigoExpLab() Then
                ObtenerExpLaboral()
                EnableOpcionesExpLaboral()
            End If
        Else
            LimpiarExpLaboral()
            DesactivarExpLaboral()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '///////////////////////////////////////////////////////////////////////// CAPACITACIONES /////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    'Private Sub Capacitacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                            cmbTipoCapac.KeyPress _
    '                          , txtCursoCapac.KeyPress _
    '                          , cbProgramadoCapac.KeyPress _
    '                          , txtFecInicioCapac.KeyPress _
    '                          , txtFecFinalCapac.KeyPress _
    '                          , txtProveedor.KeyPress _
    '                          , txtDuracionCapac.KeyPress _
    '                          , txtCostoCapac.KeyPress _
    '                          , txtObsCapacitacion.KeyPress _
    '                          , cmbMonCapac.KeyPress _
    '                          , txtMesesEvaluarCapac.KeyPress _
    '                          , txtFecEvaluacionCapac.KeyPress _
    '                          , cbEvaluadoCapac.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    'Private Sub ListarCapacitaciones()
    '    Try
    '        dtDatosCapacitaciones = oCapacitacionService.Mostrar(IdPersona).Tables(0)
    '        dgvCapacitaciones.DataSource = dtDatosCapacitaciones
    '        EnableOpcionesCapacitaciones()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LISTAR CAPACITACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub RowPossCapacitaciones(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
    '    Try
    '        Dim rows() As Janus.Windows.GridEX.GridEXRow
    '        rows = lista.GetRows
    '        For Each row In rows
    '            If CInt(row.Cells("IdCapacitacion").Value) = codigo Then
    '                lista.Row = row.Position
    '                lista.Col = 1
    '                Exit For
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox("ERROR [ROW_POSS CAPACITACIONES]: " + ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Private Sub EnableOpcionesCapacitaciones()
    '    Try
    '        If dgvCapacitaciones.RowCount > 0 Then
    '            miElimCapac.Enabled = True
    '            miEditCapac.Enabled = True
    '        Else
    '            miElimCapac.Enabled = False
    '            miEditCapac.Enabled = False
    '        End If
    '        biGrabarCapac.Enabled = edicionCapacitacion
    '        biDeshacerCapac.Enabled = edicionCapacitacion

    '        cmOpCapacitacion.Enabled = IIf(Not edicionCapacitacion, True, False)

    '        tpFichaGeneral.Enabled = IIf(edicionCapacitacion = False, True, False)
    '        tpfamiliares.Enabled = IIf(edicionCapacitacion = False, True, False)
    '        tpInstruccion.Enabled = IIf(edicionCapacitacion = False, True, False)
    '        tpExpLaboral.Enabled = IIf(edicionCapacitacion = False, True, False)
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INHABILITAR OPCIONES CAPACITACION: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub LimpiarCapacitacion()
    '    Try
    '        cmbTipoCapac.Text = ""
    '        txtCursoCapac.Text = ""
    '        cbProgramadoCapac.Checked = False
    '        txtFecInicioCapac.IsNullDate = True
    '        txtFecFinalCapac.IsNullDate = True
    '        txtDuracionCapac.Text = ""
    '        IdProveedor = 0
    '        txtProveedor.Text = ""
    '        txtCostoCapac.Value = 0
    '        txtObsCapacitacion.Text = ""
    '        txtMesesEvaluarCapac.Value = 0
    '        cbEvaluadoCapac.Checked = False
    '        cmbMonCapac.Text = ""
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LIMPIAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub DesactivarCapacitacion()
    '    Try
    '        'LimpiarCapacitacion()
    '        cmbTipoCapac.ReadOnly = True
    '        cmbTipoCapac.BackColor = System.Drawing.Color.PowderBlue
    '        txtCursoCapac.ReadOnly = True
    '        txtCursoCapac.BackColor = System.Drawing.Color.PowderBlue
    '        cbProgramadoCapac.Enabled = False
    '        txtFecInicioCapac.ReadOnly = True
    '        txtFecInicioCapac.BackColor = System.Drawing.Color.PowderBlue
    '        txtFecFinalCapac.ReadOnly = True
    '        txtFecFinalCapac.BackColor = System.Drawing.Color.PowderBlue
    '        txtDuracionCapac.ReadOnly = True
    '        txtDuracionCapac.BackColor = System.Drawing.Color.PowderBlue
    '        btnBuscarProveedor.Enabled = False
    '        btnAgregarProveedor.Enabled = False
    '        txtCostoCapac.ReadOnly = True
    '        txtCostoCapac.BackColor = System.Drawing.Color.PowderBlue
    '        txtObsCapacitacion.ReadOnly = True
    '        txtObsCapacitacion.BackColor = System.Drawing.Color.PowderBlue
    '        txtMesesEvaluarCapac.ReadOnly = True
    '        txtMesesEvaluarCapac.BackColor = System.Drawing.Color.PowderBlue
    '        cbEvaluadoCapac.Enabled = False
    '        txtFecEvaluacionCapac.ReadOnly = True
    '        txtFecEvaluacionCapac.BackColor = System.Drawing.Color.PowderBlue
    '        cmbMonCapac.ReadOnly = True
    '        cmbMonCapac.BackColor = System.Drawing.Color.PowderBlue
    '        edicionCapacitacion = False
    '        EnableOpcionesCapacitaciones()
    '        dgvCapacitaciones.Focus()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL DESACTIVAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub ActivarCapacitacion()
    '    Try
    '        cmbTipoCapac.ReadOnly = False
    '        cmbTipoCapac.BackColor = System.Drawing.SystemColors.Window
    '        cmbTipoCapac.SelectedIndex = 0
    '        txtCursoCapac.ReadOnly = False
    '        txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
    '        cbProgramadoCapac.Enabled = True
    '        txtFecInicioCapac.ReadOnly = False
    '        txtFecInicioCapac.BackColor = System.Drawing.SystemColors.Window
    '        txtFecInicioCapac.IsNullDate = False
    '        txtFecInicioCapac.Value = Today
    '        txtFecFinalCapac.ReadOnly = False
    '        txtFecFinalCapac.BackColor = System.Drawing.SystemColors.Window
    '        txtFecFinalCapac.IsNullDate = False
    '        txtFecFinalCapac.Value = Today
    '        txtDuracionCapac.ReadOnly = False
    '        txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
    '        btnBuscarProveedor.Enabled = True
    '        btnAgregarProveedor.Enabled = True
    '        txtCostoCapac.ReadOnly = False
    '        txtCostoCapac.BackColor = System.Drawing.SystemColors.Window
    '        txtObsCapacitacion.ReadOnly = False
    '        txtObsCapacitacion.BackColor = System.Drawing.SystemColors.Window
    '        txtMesesEvaluarCapac.ReadOnly = False
    '        txtMesesEvaluarCapac.BackColor = System.Drawing.SystemColors.Window
    '        cbEvaluadoCapac.Enabled = True
    '        cmbMonCapac.ReadOnly = False
    '        cmbMonCapac.BackColor = System.Drawing.SystemColors.Window
    '        cmbMonCapac.Value = "NS"
    '        edicionCapacitacion = True
    '        EnableOpcionesCapacitaciones()
    '        cmbTipoCapac.Focus()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL ACTIVAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub ObtenerCapacitacion()
    '    Try
    '        Dim registro As CapacitacionService.Capacitacion
    '        registro = oCapacitacionService.Obtener(toNumber(dgvCapacitaciones.CurrentRow.Cells("IdCapacitacion").Value))
    '        IdCapacitacion = registro.IdCapacitacion
    '        cmbTipoCapac.Value = registro.Tipo
    '        txtCursoCapac.Text = registro.NombreCurso
    '        cbProgramadoCapac.Checked = registro.Programado
    '        txtFecInicioCapac.Value = CDate(registro.FechaInicio)
    '        txtFecInicioCapac.Text = registro.FechaInicio.ToString
    '        txtFecFinalCapac.Value = CDate(registro.FechaFinal)
    '        txtFecFinalCapac.Text = registro.FechaFinal.ToString
    '        txtDuracionCapac.Text = registro.Duracion
    '        IdProveedor = registro.Proveedor.IdProveedor
    '        txtProveedor.Text = registro.Proveedor.DesProv
    '        txtCostoCapac.Value = registro.Costo
    '        txtObsCapacitacion.Text = registro.Observacion
    '        txtMesesEvaluarCapac.Value = registro.MesEvaluar
    '        cbEvaluadoCapac.Checked = registro.Evaluado
    '        If Not (registro.FechaEvaluado.ToString = "") Then
    '            txtFecEvaluacionCapac.IsNullDate = False
    '            txtFecEvaluacionCapac.Value = CDate(registro.FechaEvaluado)
    '            txtFecEvaluacionCapac.Text = registro.FechaEvaluado.ToString
    '        Else
    '            txtFecEvaluacionCapac.IsNullDate = True
    '        End If
    '        cmbMonCapac.Value = registro.Moneda.CodMon

    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub InsertarCapacitacion(ByVal registro As CapacitacionService.Capacitacion)
    '    Try
    '        Dim estado_process As Integer
    '        estado_process = oCapacitacionService.Insertar(registro)
    '        type_process = "insert"
    '        If estado_process > 0 Then              
    '            MsgBox("Se insertó la Capacitación Correctamente.")
    '            dtDatosCapacitaciones = Nothing
    '            ActualizarCapacitacion()
    '            IdCapacitacion = estado_process
    '            RowPossCapacitaciones(dgvCapacitaciones, IdCapacitacion)
    '            edicionCapacitacion = False
    '            ObtenerCapacitacion()
    '            DesactivarCapacitacion()
    '        Else
    '            MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INSERTAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub ModificarCapacitacion(ByVal registro As CapacitacionService.Capacitacion)
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oCapacitacionService.Actualizar(registro)
    '        type_process = "update"
    '        If estado_process = True Then
    '            MsgBox("Se modificó la Capacitación Correctamente.")
    '            dtDatosCapacitaciones = Nothing
    '            ActualizarCapacitacion()
    '            RowPossCapacitaciones(dgvCapacitaciones, IdCapacitacion)
    '            edicionCapacitacion = False
    '            ObtenerCapacitacion()
    '            DesactivarCapacitacion()
    '        Else
    '            MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MODIFICAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub ActualizarCapacitacion()
    '    Try
    '        Dim codigo As String = ""
    '        If dgvCapacitaciones.RowCount > 0 Then
    '            If IsDBNull(dgvCapacitaciones.CurrentRow.Cells(0).Text) = False Then
    '                codigo = dgvCapacitaciones.CurrentRow.Cells("IdCapacitacion").Text
    '            End If
    '        End If
    '        dtDatosCapacitaciones = Nothing
    '        ListarCapacitaciones()
    '        If dgvCapacitaciones.RowCount > 0 And codigo.Trim.Length > 0 Then
    '            RowPossCapacitaciones(dgvCapacitaciones, codigo)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL ACTUALIZAR DETALLES CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Function ValidaCamposCapacitacion() As Boolean
    '    Try
    '        If toBlank(cmbTipoCapac.Value) = "" Then
    '            MsgBox("Debe Ingresar el Tipo de capacitación.", MsgBoxStyle.Information, "Información")
    '            cmbTipoCapac.Focus()
    '            Return False
    '        ElseIf toBlank(txtCursoCapac.Text) = "" Then
    '            MsgBox("Debe Ingresar el nombre del Curso.", MsgBoxStyle.Information, "Información")
    '            txtCursoCapac.Focus()
    '            Return False
    '        ElseIf toBlank(txtFecInicioCapac.Text) = "" Then
    '            MsgBox("Debe Ingresar la Fecha de Inicio.", MsgBoxStyle.Information, "Información")
    '            txtFecInicioCapac.Focus()
    '            Return False
    '        ElseIf toBlank(txtFecFinalCapac.Text) = "" Then
    '            MsgBox("Debe Ingresar la Fecha Final.", MsgBoxStyle.Information, "Información")
    '            txtFecFinalCapac.Focus()
    '            Return False
    '        ElseIf txtFecInicioCapac.Value > txtFecFinalCapac.Value Then
    '            MsgBox("La fecha de Inicio no debe ser mayor a la fecha Final.", MsgBoxStyle.Information, "Información")
    '            txtFecFinalCapac.Focus()
    '            Return False
    '        ElseIf txtDuracionCapac.Text = "" Then
    '            MsgBox("Debe Ingresar la Duración.", MsgBoxStyle.Information, "Información")
    '            txtDuracionCapac.Focus()
    '            Return False           
    '        ElseIf toBlank(cmbMonCapac.Value) = "" Then
    '            MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
    '            cmbMonCapac.Focus()
    '            Return False
    '        ElseIf toNumber(IdProveedor) = 0 Then
    '            MsgBox("Debe Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
    '            txtProveedor.Focus()
    '            Return False
    '            'ElseIf toDouble(txtCostoCapac.Value) = 0 Then
    '            '    MsgBox("Debe Ingresar el Costo.", MsgBoxStyle.Information, "Información")
    '            '    txtCostoCapac.Focus()
    '            '    Return False
    '        ElseIf cbEvaluadoCapac.Checked = True And toBlank(txtFecEvaluacionCapac.Text) = "" Then
    '            MsgBox("Debe Ingresar la Fecha de Evaluación.", MsgBoxStyle.Information, "Información")
    '            txtFecEvaluacionCapac.Focus()
    '            Return False
    '        ElseIf toBlank(txtFecEvaluacionCapac.Text) <> "" And (txtFecEvaluacionCapac.Value < txtFecFinalCapac.Value) Then
    '            MsgBox("La fecha de Evaluación no debe ser menor a la fecha Final.", MsgBoxStyle.Information, "Información")
    '            txtFecEvaluacionCapac.Focus()
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR DATOS CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Function

    'Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarProveedor.Enabled = True Then
    '            e.Handled = True
    '            btnAgregarProveedor_Click(sender, e)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
    '    Try
    '        Dim frm As New frmBuscarProveedor
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            If toNull(frm.codigo) <> Nothing Then
    '                IdProveedor = frm.codigo
    '                txtProveedor.Text = frm.descripcion
    '                txtCostoCapac.Focus()
    '            Else
    '                IdProveedor = 0
    '                txtProveedor.Text = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub btnAgregarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
    '    Try
    '        Dim frm As New frmProveedor
    '        frm.state_button = False
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            IdProveedor = frm.IdProveedor
    '            txtProveedor.Text = frm.DesProv
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub biDeshacerCapac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerCapac.Click
    '    If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
    '        If Not state_capacitacion Then
    '            If dgvCapacitaciones.RowCount > 0 Then
    '                edicionCapacitacion = True
    '                ObtenerCapacitacion()
    '                DesactivarCapacitacion()
    '            Else
    '                edicionCapacitacion = False
    '                DesactivarCapacitacion()
    '                LimpiarCapacitacion()
    '            End If
    '            EnableOpcionesCapacitaciones()
    '        Else
    '            edicionCapacitacion = True
    '            ObtenerCapacitacion()
    '            DesactivarCapacitacion()
    '        End If
    '    End If
    'End Sub

    'Private Sub biGrabarCapac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabarCapac.Click
    '    Try
    '        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '            If ValidaCamposCapacitacion() Then
    '                Dim registro As New CapacitacionService.Capacitacion
    '                Dim Persona As New CapacitacionService.Persona
    '                Dim Proveedor As New CapacitacionService.Proveedor
    '                Dim Moneda As New CapacitacionService.Moneda

    '                registro.IdCapacitacion = IdCapacitacion
    '                Persona.IdPer = IdPersona
    '                registro.Persona = Persona
    '                registro.Tipo = cmbTipoCapac.Value
    '                registro.NombreCurso = txtCursoCapac.Text
    '                registro.Programado = cbProgramadoCapac.Checked
    '                registro.FechaInicio = txtFecInicioCapac.Value
    '                registro.FechaFinal = txtFecFinalCapac.Value
    '                registro.Duracion = txtDuracionCapac.Text
    '                Proveedor.IdProveedor = IdProveedor
    '                registro.Proveedor = Proveedor
    '                registro.Costo = toDouble(txtCostoCapac.Value)
    '                registro.Observacion = txtObsCapacitacion.Text
    '                registro.MesEvaluar = txtMesesEvaluarCapac.Value
    '                registro.Evaluado = cbEvaluadoCapac.Checked
    '                registro.FechaEvaluado = IIf(txtFecEvaluacionCapac.Text = "", Nothing, txtFecEvaluacionCapac.Value)
    '                Moneda.CodMon = cmbMonCapac.Value
    '                registro.Moneda = Moneda

    '                registro.CodUsu = Session.sCodUsu
    '                registro.DirIp = Session.sDirIp
    '                registro.FecReg = Today
    '                registro.NomPc = Session.sNomPc

    '                If state_capacitacion = False Then
    '                    InsertarCapacitacion(registro)
    '                Else
    '                    ModificarCapacitacion(registro)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL GUARDAR CAPACITACIÓN:" + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub miEditCapac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEditCapac.Click
    '    state_capacitacion = True
    '    ActivarCapacitacion()
    '    ObtenerCapacitacion()
    'End Sub

    'Private Sub miNuevoCapac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevoCapac.Click
    '    state_capacitacion = False
    '    LimpiarCapacitacion()
    '    ActivarCapacitacion()
    'End Sub

    'Private Sub miElimCapac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miElimCapac.Click
    '    Try
    '        cmOpCapacitacion.Visible = False
    '        If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
    '            Dim estado_process As Boolean
    '            estado_process = oCapacitacionService.Borrar(toNumber(dgvCapacitaciones.CurrentRow.Cells("IdCapacitacion").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '            If estado_process = True Then
    '                dtDatosCapacitaciones = Nothing
    '                ListarCapacitaciones()
    '                MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
    '            Else
    '                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL ELIMINAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub miActCapac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActCapac.Click
    '    ActualizarCapacitacion()
    'End Sub

    'Private Function ValidaCodigoCapacitacion() As Boolean
    '    Try
    '        If dgvCapacitaciones.RowCount < 1 Then
    '            MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
    '            Return False
    '        ElseIf dgvCapacitaciones.CurrentRow.RowIndex < 0 Then
    '            MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
    '            Return False
    '        ElseIf dgvCapacitaciones.CurrentRow.Cells(0).Text = Nothing Then
    '            MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Function

    'Private Sub dgvCapacitaciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCapacitaciones.SelectionChanged
    '    If dgvCapacitaciones.RowCount > 0 Then
    '        If ValidaCodigoCapacitacion() Then
    '            ObtenerCapacitacion()
    '            DesactivarCapacitacion()
    '            EnableOpcionesCapacitaciones()
    '        End If
    '    Else
    '        LimpiarCapacitacion()
    '        DesactivarCapacitacion()
    '    End If
    'End Sub

    'Private Sub cbEvaluadoCapac_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEvaluadoCapac.CheckedChanged
    '    If cbEvaluadoCapac.Checked = True Then
    '        txtFecEvaluacionCapac.ReadOnly = False
    '        txtFecEvaluacionCapac.BackColor = System.Drawing.SystemColors.Window
    '        txtFecEvaluacionCapac.IsNullDate = False
    '        txtFecEvaluacionCapac.Value = Today
    '    Else
    '        txtFecEvaluacionCapac.ReadOnly = True
    '        txtFecEvaluacionCapac.BackColor = System.Drawing.Color.PowderBlue
    '        txtFecEvaluacionCapac.IsNullDate = True
    '    End If    
    'End Sub


    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////// CESES //////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    Private Sub Cese_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        cmbFecIngresoCese.KeyPress _
          , cmbFecCeseCese.KeyPress _
          , txtMotivoCese.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub RowPossCese(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCese").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS CESE]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EnableOpcionesCese()
        Try
            If dgvCese.RowCount > 0 Then
                mbBorrarCese.Enabled = True
                mbEditarCese.Enabled = True
            Else
                mbBorrarCese.Enabled = False
                mbEditarCese.Enabled = False
            End If
            btnGuardarCese.Enabled = edicionCese
            btnDesacerCese.Enabled = edicionCese

            dgvCese.Enabled = IIf(Not edicionCese, True, False)
            cmOpCese.Enabled = IIf(Not edicionCese, True, False)

            tpFichaGeneral.Enabled = IIf(edicionCese = False, True, False)
            tpIdioma.Enabled = IIf(edicionCese = False, True, False)
            tpfamiliares.Enabled = IIf(edicionCese = False, True, False)
            tpExpLaboral.Enabled = IIf(edicionCese = False, True, False)
            tpInstruccion.Enabled = IIf(edicionCese = False, True, False)
            'gbCese.Enabled = IIf(edicionCese = False, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES CESES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListarCeses()
        Try
            dtCese = oPersonaService.MostrarCese(IdPersona).Tables(0)
            dgvCese.DataSource = dtCese
            EnableOpcionesCese()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR INFORMÁTICA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub DesactivarCeses()
        Try

            cmbFecIngresoCese.ReadOnly = True
            cmbFecIngresoCese.BackColor = System.Drawing.Color.PowderBlue
            cmbFecCeseCese.ReadOnly = True
            cmbFecCeseCese.BackColor = System.Drawing.Color.PowderBlue
            txtMotivoCese.ReadOnly = True
            txtMotivoCese.BackColor = System.Drawing.Color.PowderBlue
            edicionCese = False
            EnableOpcionesCese()
            dgvCese.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CESES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActivarCese()
        Try
            cmbFecIngresoCese.ReadOnly = False
            cmbFecIngresoCese.BackColor = System.Drawing.SystemColors.Window
            cmbFecIngresoCese.IsNullDate = False
            cmbFecIngresoCese.Value = Today
            cmbFecCeseCese.ReadOnly = False
            cmbFecCeseCese.BackColor = System.Drawing.SystemColors.Window
            cmbFecCeseCese.IsNullDate = False
            cmbFecCeseCese.Value = Today
            txtMotivoCese.ReadOnly = False
            txtMotivoCese.BackColor = System.Drawing.SystemColors.Window
            edicionCese = True
            EnableOpcionesCese()
            txtMotivoCese.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerCese()
        Try
            Dim registro As PersonaService.CesePersonal
            registro = oPersonaService.ObtenerCese(toNumber(dgvCese.CurrentRow.Cells("IdCese").Value))
            IdCese = registro.IdCese

            If Not (registro.FecIngreso.ToString = "") Then
                cmbFecIngresoCese.IsNullDate = False
                cmbFecIngresoCese.Value = CDate(registro.FecIngreso)
                cmbFecIngresoCese.Text = registro.FecIngreso.ToString
            Else
                cmbFecIngresoCese.IsNullDate = True
            End If
            If Not (registro.FecCese.ToString = "") Then
                cmbFecCeseCese.IsNullDate = False
                cmbFecCeseCese.Value = CDate(registro.FecCese)
                cmbFecCeseCese.Text = registro.FecCese.ToString
            Else
                cmbFecCeseCese.IsNullDate = True
            End If
            txtMotivoCese.Text = registro.Motivo
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InsertarCese(ByVal registro As PersonaService.CesePersonal)
        Try
            Dim estado_process As Int64
            estado_process = oPersonaService.InsertarCese(registro)
            type_process = "insert"
            If estado_process > 0 Then
                MsgBox("Se insertó el Cese Correctamente.")
                dtCese = Nothing
                ActualizarCese()
                IdCese = estado_process
                RowPossCese(dgvCese, IdCese)
                edicionCese = False
                ObtenerCese()
                DesactivarCeses()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ModificarCese(ByVal registro As PersonaService.CesePersonal)
        Try
            Dim estado_process As Boolean
            estado_process = oPersonaService.ActualizarCese(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Cese Correctamente.")
                dtCese = Nothing
                ActualizarCese()
                RowPossCese(dgvCese, IdCese)
                edicionCese = False
                ObtenerCese()
                DesactivarCeses()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarCese()
        Try
            Dim codigo As String = ""
            If dgvCese.RowCount > 0 Then
                If IsDBNull(dgvCese.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvCese.CurrentRow.Cells("IdCese").Text
                End If
            End If
            dtCese = Nothing
            ListarCeses()
            If dgvCese.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossCese(dgvCese, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacerCese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesacerCese.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_cese Then
                If dgvCese.RowCount > 0 Then
                    edicionCese = True
                    ObtenerCese()
                    DesactivarCeses()
                Else
                    edicionCese = False
                    DesactivarCeses()
                    LimpiarCese()
                End If
                EnableOpcionesCese()
            Else
                edicionCese = True
                ObtenerCese()
                DesactivarCeses()
            End If
        End If
    End Sub

    Private Sub biGrabarCese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCese.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim registro As New PersonaService.CesePersonal
                Dim Persona As New PersonaService.Persona

                registro.IdCese = IdCese
                Persona.IdPer = IdPersona
                registro.Persona = Persona
                registro.FecIngreso = cmbFecIngresoCese.Value
                registro.FecCese = IIf(cmbFecCeseCese.Text = "", Nothing, cmbFecCeseCese.Value)
                registro.Motivo = txtMotivoCese.Text
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc

                If state_cese = False Then
                    InsertarCese(registro)
                Else
                    ModificarCese(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL CESE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEditCese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mbEditarCese.Click
        state_cese = True
        ActivarCese()
        ObtenerCese()
    End Sub

    Private Sub miNuevoCese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mbNuevoCese.Click
        state_cese = False
        LimpiarCese()
        ActivarCese()
        cmbFecIngresoCese.Value = txtFechaIngreso.Value
    End Sub

    Private Sub miElimCese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mbBorrarCese.Click
        Try
            cmOpCese.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPersonaService.BorrarCese(toNumber(dgvCese.CurrentRow.Cells("IdCese").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtCese = Nothing
                    ListarCeses()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActCese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mbActualizarCese.Click
        ActualizarCese()
    End Sub

    Private Function ValidaCodigoCese() As Boolean
        Try
            If dgvCese.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCese.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCese.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvCese_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCese.SelectionChanged
        If dgvCese.RowCount > 0 Then
            If ValidaCodigoCese() Then
                ObtenerCese()
                EnableOpcionesCese()
            End If
        Else
            LimpiarCese()
            DesactivarCeses()
        End If
    End Sub

    Private Sub LimpiarCese()
        Try

            cmbFecIngresoCese.IsNullDate = True
            cmbFecCeseCese.IsNullDate = True
            txtMotivoCese.Text = ""
        Catch ex As Exception
            MsgBox("ERROR AL LIMPIAR CESE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '/////////////////////////////////////////////////////////////////////////// FOTOGRAFÍA ///////////////////////////////////////////////////////////////////////////////////////////
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    Private Sub btnBuscarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFoto.Click
        Dim file As New OpenFileDialog()
        Dim tamaño As Long
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            tamaño = FileLen(file.FileName)
            'If tamaño > 16384 Then
            '    MsgBox("La imagen a adjuntar no debe pesar mas de 16 KB.", MsgBoxStyle.Information, "Información")
            'Else
            pbFoto.Image = Image.FromFile(file.FileName)
            'End If
        End If
    End Sub

    Private Sub btnDesscargarFoto_Click(sender As Object, e As EventArgs) Handles btnDesscargarFoto.Click

        Dim registro As PersonaService.Persona
        registro = oPersonaService.Obtener(IdPersona)

        File.WriteAllBytes("D:\foto.jpeg", registro.Foto)
        MsgBox("Se descargo la foto en la siguiente ruta : D:\foto.jpeg", MsgBoxStyle.Information)

    End Sub


    Private Sub txtFechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaIngreso.ValueChanged
        txtFecIniPlanilla.Value = txtFechaIngreso.Value
    End Sub
End Class