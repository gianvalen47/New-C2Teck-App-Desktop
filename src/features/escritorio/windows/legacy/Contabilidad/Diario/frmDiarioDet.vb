Imports System.ServiceModel
Public Class frmDiarioDet

    '===========================Servicios====================================
    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    'Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oContabilidadDetService As New ContabilidadDetService.ContabilidadDetServiceClient    

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public IdContabilidadDet As Integer
    Public IdContabilidad As Integer
    Public IdProveedor As Integer
    Public IdPersona As Integer                ' Id de Colaborador Diario Tipo Planilla
    Public IdCliente As Int64
    Public CodLibro As Integer                 ' CodTipoLibro
    Public CodMon As String    
    Public TipoCambio As Double
    Private dtTipoMov As DataTable
    Private dtTipDoc As DataTable

    Public dtDatos As DataTable
    Private Calcular As Boolean = True

    Private Sub frmDiarioDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        lblDesCuenta.Text = ""
        lblDesCuentaDest.Text = ""
        If state_button Then    'Modificar
            Calcular = False
            ObtenerRegistro()
            Calcular = True
            Desactivar()
            gbCentroCosto.Visible = True
            actualizarDetalles()
            Me.Text = "Diario Detalle"
            biAsignar.Focus()
        Else                          'Nuevo
            Calcular = True
            Me.Size = New System.Drawing.Size(591, 413)
            gbCentroCosto.Visible = False
            Me.Text = "Registrar nuevo Diario Detalle"
            Activar()
            cmbTipoMov.Value = "D"
            txtCodCuenta.Focus()
        End If
    End Sub

    Private Sub frmDiarioDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If ValidarMontos() = False Then
                MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
                biAsignar.Focus()
            Else
                Finalizar()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmDiarioDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'If ValidarMontos() = False Then
        '    MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
        '    biAsignar.Focus()
        'Else
        Finalizar()
        'End If
    End Sub

    Private Sub Finalizar()
        Try
            oJobService.Close()
            oMaestroService.Close()
            'oPersonaService.Close()
            oCuentaContableService.Close()
            oContabilidadService.Close()
            oContabilidadDetService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            'oPersonaService.Abort()
            oCuentaContableService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            'oPersonaService.Abort()
            oCuentaContableService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
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
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oContabilidadDetService.MostrarTipoDocumentoConta().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing

            '======================================= TIPO MOV ===============================================
            dtTipoMov = New DataTable
            dtTipoMov.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipoMov.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipoMov.Rows.Add(New Object() {"D", "Debe"}) ', New DateTime(2008, 2, 5)
            dtTipoMov.Rows.Add(New Object() {"H", "Haber"})

            cmbTipoMov.DataSource = dtTipoMov
            cmbTipoMov.DropDownList.DataMember = dtTipoMov.Columns("codigo").ToString
            cmbTipoMov.DropDownList.DisplayMember = dtTipoMov.Columns("codigo").ToString
            cmbTipoMov.DropDownList.ValueMember = dtTipoMov.Columns("codigo").ToString
            cmbTipoMov.DropDownList.Columns(0).DataMember = dtTipoMov.Columns("codigo").ToString
            cmbTipoMov.DropDownList.Columns(1).DataMember = dtTipoMov.Columns("nombre").ToString
            dtTipoMov = Nothing

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            ''dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            'cmbArea.DataSource = dtAreas
            'cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            'cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            'cmbArea.SelectedIndex = 0
            'dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        miAsignar.Enabled = IIf(editable, True, False)
        biAsignar.Enabled = IIf(editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Protected Sub Activar()
        Try
            If state_button Then    'Actualizar
                txtCodCuenta.ReadOnly = False
                txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
                btnBuscarCuenta.Enabled = True
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbTipoMov.ReadOnly = False
                cmbTipoMov.BackColor = System.Drawing.SystemColors.Window
                txtCodCuentaDest.ReadOnly = False
                txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Window
                btnBuscarCuentaDest.Enabled = False
                txtProveedor.ReadOnly = True
                txtProveedor.BackColor = System.Drawing.SystemColors.Control
                btnBuscarProveedor.Enabled = True
                btnAgregarProveedor.Enabled = True
                txtColaborador.ReadOnly = True
                txtColaborador.BackColor = System.Drawing.SystemColors.Control
                btnBuscarPersona.Enabled = True

                txtCliente.ReadOnly = True
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                btnBuscarCliente.Enabled = True

                txtCodTipoDoc.ReadOnly = False
                txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Window
                cmbTipoDoc.ReadOnly = False
                cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                txtSerieDoc.ReadOnly = False
                txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                txtNumDoc.ReadOnly = False
                txtNumDoc.BackColor = System.Drawing.SystemColors.Window

                '-------- Se agregó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos --------
                txtMontoSol.ReadOnly = False
                txtMontoSol.BackColor = System.Drawing.SystemColors.Window
                txtMontoDol.ReadOnly = False
                txtMontoDol.BackColor = System.Drawing.SystemColors.Window
                '--------------------------------------------------------------------------------------------------------------------------------

                '------ Se comentó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos ------
                'If CodMon = "NS" Then
                '    txtMontoSol.ReadOnly = False
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoDol.ReadOnly = True
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Control

                'ElseIf CodMon = "US" Then
                '    txtMontoDol.ReadOnly = False
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoSol.ReadOnly = True
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Control
                'End If
                '--------------------------------------------------------------------------------------------------------------------------------

                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()
                txtCodCuenta.Focus()
            Else                          'Nuevo
                txtCodCuenta.ReadOnly = False
                txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
                btnBuscarCuenta.Enabled = True
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbTipoMov.ReadOnly = False
                cmbTipoMov.BackColor = System.Drawing.SystemColors.Window
                txtCodCuentaDest.ReadOnly = False
                txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Window
                btnBuscarCuentaDest.Enabled = False
                txtProveedor.ReadOnly = True
                txtProveedor.BackColor = System.Drawing.SystemColors.Control
                btnBuscarProveedor.Enabled = True
                btnAgregarProveedor.Enabled = True
                txtColaborador.ReadOnly = True
                txtColaborador.BackColor = System.Drawing.SystemColors.Control
                btnBuscarPersona.Enabled = True
                txtCodTipoDoc.ReadOnly = False
                txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Window
                cmbTipoDoc.ReadOnly = False
                cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                txtSerieDoc.ReadOnly = False
                txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                txtNumDoc.ReadOnly = False
                txtNumDoc.BackColor = System.Drawing.SystemColors.Window

                '-------- Se agregó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos --------
                txtMontoSol.ReadOnly = False
                txtMontoSol.BackColor = System.Drawing.SystemColors.Window
                txtMontoDol.ReadOnly = False
                txtMontoDol.BackColor = System.Drawing.SystemColors.Window
                '--------------------------------------------------------------------------------------------------------------------------------

                '------ Se comentó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos ------
                'If CodMon = "NS" Then
                '    txtMontoSol.ReadOnly = False
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoDol.ReadOnly = True
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Control

                'ElseIf CodMon = "US" Then
                '    txtMontoDol.ReadOnly = False
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoSol.ReadOnly = True
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Control
                'End If
                '--------------------------------------------------------------------------------------------------------------------------------

                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                edicion = True
                enableOpciones()
                txtCodCuenta.Focus()
            End If           
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            txtCodCuenta.ReadOnly = True
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCuenta.Enabled = False
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False
            cmbTipoMov.ReadOnly = True
            cmbTipoMov.BackColor = System.Drawing.SystemColors.Control
            txtCodCuentaDest.ReadOnly = True
            txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCuentaDest.Enabled = False
            txtProveedor.ReadOnly = True
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = False
            btnAgregarProveedor.Enabled = False

            txtCliente.ReadOnly = True
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCliente.Enabled = False

            txtColaborador.ReadOnly = True
            txtColaborador.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = False
            txtCodTipoDoc.ReadOnly = True
            txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Control
            cmbTipoDoc.ReadOnly = True
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
            txtSerieDoc.ReadOnly = True
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtMontoSol.ReadOnly = True
            txtMontoSol.BackColor = System.Drawing.SystemColors.Control
            txtMontoDol.ReadOnly = True
            txtMontoDol.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control

            edicion = False
            enableOpciones()
            biAsignar.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodCuenta.Text = "" Then
                MsgBox("Debe Ingresar el Código de Cuenta.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Focus()
                Return False
            ElseIf Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuenta.Text)) Then
                MsgBox("Código de Cuenta incorrecto, Verificar.", MsgBoxStyle.Information, "Información")
                txtCodCuenta.Text = ""
                txtCodCuenta.Focus()
                Return False
                'ElseIf toBlank(cmbArea.Value) = "" Then
                '    MsgBox("Debe Ingresar el Área.", MsgBoxStyle.Information, "Información")
                '    cmbArea.Focus()
                '    Return False
                'ElseIf toBlank(cmbCentroCosto.Value) = "" Then
                '    MsgBox("Debe Ingresar el Centro de Costo.", MsgBoxStyle.Information, "Información")
                '    cmbCentroCosto.Focus()
                '    Return False
            ElseIf toBlank(cmbTipoMov.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Movimiento.", MsgBoxStyle.Information, "Información")
                cmbTipoMov.Focus()
                Return False
                'ElseIf txtCodCuentaDest.Text = "" Then
                '    MsgBox("Debe Ingresar el Código de Cuenta Destino. ", MsgBoxStyle.Information, "Información")
                '    txtCodCuentaDest.Focus()
                '    Return False
                'ElseIf IdProveedor = 0 Then
                '    MsgBox("Debe Ingresar el Proveedor. ", MsgBoxStyle.Information, "Información")
                '    txtProveedor.Focus()
                '    Return False
            ElseIf toNumber(cmbTipoDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar el Número de Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf CodMon = "NS" And toDouble(txtMontoSol.Value) <= 0 Then
                MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                txtMontoSol.Focus()
                Return False
            ElseIf CodMon = "US" And toDouble(txtMontoDol.Value) <= 0 Then
                MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                txtMontoDol.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ContabilidadDetService.ContabilidadDet
            registro = oContabilidadDetService.Obtener(IdContabilidadDet)

            IdContabilidadDet = registro.IdContabilidadDet
            IdContabilidad = registro.Contabilidad.IdContabilidad
            lblDesCuenta.Text = Trim(registro.CuentaContable.NomCuenta)
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)
            txtNumJob.Text = registro.Job.CodJob
            'cmbArea.Value = registro.CentroCosto.Area.CodArea
            'cmbCentroCosto.Value = registro.CentroCosto.CodCentro

            lblDesCuentaDest.Text = Trim(registro.CuentaContableDest.NomCuenta)
            txtCodCuentaDest.Text = toNull(registro.CuentaContableDest.CodCuenta)
            cmbTipoMov.Value = registro.TipMov

            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv

            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom

            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli

            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtCodTipoDoc.Text = registro.TipoDocumento.CodSunat
            txtSerieDoc.Text = registro.SerDoc
            txtNumDoc.Text = registro.NumDoc
            calcular = False
            txtMontoSol.Value = registro.MontoSol
            txtMontoDol.Value = registro.MontoDol
            calcular = True
            txtObservacion.Text = registro.Observacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmAgregar_CentroCosto
            frm.IdContabilidadDet = IdContabilidadDet
            frm.IdContabilidad = IdContabilidad
            frm.MontoSoles = txtMontoSol.Value
            frm.MontoDolares = txtMontoDol.Value          
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

    Private Sub Insertar(ByVal registro As ContabilidadDetService.ContabilidadDet)
        Try
            Dim estado_process As Integer
            estado_process = oContabilidadDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdContabilidadDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ContabilidadDetService.ContabilidadDet)
        Try
            Dim estado_process As Boolean
            estado_process = oContabilidadDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oContabilidadDetService.MostrarCentroCosto(IdContabilidadDet).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New ContabilidadDetService.ContabilidadDet
                Dim Contabilidad As New ContabilidadDetService.Contabilidad
                Dim CuentaContable As New ContabilidadDetService.CuentaContable
                Dim CuentaContableDest As New ContabilidadDetService.CuentaContable
                'Dim CentroCosto As New ContabilidadDetService.CentroCosto
                'Dim Area As New ContabilidadDetService.Area
                Dim Job As New ContabilidadDetService.Job
                Dim Proveedor As New ContabilidadDetService.Proveedor
                Dim Persona As New ContabilidadDetService.Persona
                Dim TipoDocumento As New ContabilidadDetService.TipoDocumento
                Dim cliente As New ContabilidadDetService.Cliente

                registro.IdContabilidadDet = IdContabilidadDet
                Contabilidad.IdContabilidad = IdContabilidad
                registro.Contabilidad = Contabilidad

                CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                CuentaContable.CodCuenta = txtCodCuenta.Text
                registro.CuentaContable = CuentaContable

                Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                registro.Job = Job
                'Area.CodArea = cmbArea.Value
                'CentroCosto.CodCentro = cmbCentroCosto.Value
                'CentroCosto.Area = Area
                'registro.CentroCosto = CentroCosto

                registro.TipMov = cmbTipoMov.Value
                CuentaContableDest.IdCuenta = IIf(txtCodCuentaDest.Text = "", Nothing, oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text))
                CuentaContableDest.CodCuenta = IIf(txtCodCuentaDest.Text = "", Nothing, txtCodCuentaDest.Text)
                registro.CuentaContableDest = CuentaContableDest

                TipoDocumento.IdDocumento = cmbTipoDoc.Value
                registro.TipoDocumento = TipoDocumento
                registro.SerDoc = IIf(txtSerieDoc.Text = "", Nothing, txtSerieDoc.Text)
                registro.NumDoc = txtNumDoc.Text
                Proveedor.IdProveedor = IIf(toNumber(IdProveedor) = 0, Nothing, IdProveedor)
                registro.Proveedor = Proveedor

                cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
                registro.Cliente = cliente

                Persona.IdPer = IIf(IdPersona = 0, Nothing, IdPersona)
                registro.Persona = Persona
                registro.MontoSol = txtMontoSol.Value
                registro.MontoDol = txtMontoDol.Value

                registro.Observacion = txtObservacion.Text

                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc
                registro.FecReg = Today

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If ValidarMontos() = False Then
            MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
            biAsignar.Focus()    
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
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

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Private Sub miAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAsignar.Click, biAsignar.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
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
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    'cmbArea.Focus()
                    cmbTipoMov.Focus()
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbTipoMov.Focus()
                End If
            Else
                cmbTipoMov.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbTipoMov.Focus()
                End If
            Else
                'cmbArea.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtCodTipoDoc.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtCodTipoDoc.Focus()
        End If
    End Sub

    'Private Sub cmbArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbArea.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        cmbCentroCosto.Focus()
    '    End If
    'End Sub

    'Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
    '    Try
    '        If cmbArea.Value <> "" Then
    '            '====================================== CENTRO COSTO ===========================================
    '            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
    '            'dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
    '            cmbCentroCosto.DataSource = dtCentroCosto
    '            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
    '            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
    '            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
    '            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
    '            cmbCentroCosto.SelectedIndex = 0
    '            dtCentroCosto = Nothing
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub cmbCentroCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCentroCosto.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        cmbTipoMov.Focus()
    '    End If
    'End Sub

    Private Sub cmbTipoMov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoMov.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtCodCuentaDest.Focus()
        End If
    End Sub

    Private Sub btnBuscarCuentaDest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuentaDest.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            'frm.txtCodCuenta.Text = "10"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuentaDest.Text = frm.codigo
                    lblDesCuentaDest.Text = frm.descripcion
                Else
                    txtCodCuentaDest.Text = ""
                    lblDesCuentaDest.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable Destino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCuenta.Click
        Try
            Dim frm As New frmBuscarCuentaContable
            'frm.txtCodCuenta.Text = "10"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCodCuenta.Text = frm.codigo
                    lblDesCuenta.Text = frm.descripcion
                Else
                    txtCodCuenta.Text = ""
                    lblDesCuenta.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Buscar Cuenta Contable : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuenta.Enabled = True Then
                e.Handled = True
                btnBuscarCuenta_Click(sender, e)
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
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuenta.Text = registro.NomCuenta
                    txtNumJob.Focus()
                End If
            Else
                txtNumJob.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuenta.Validated
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
                txtNumJob.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtCodCuentaDest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuentaDest.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCuentaDest.Enabled = True Then
                e.Handled = True
                btnBuscarCuentaDest_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If Len(Trim(txtCodCuentaDest.Text)) > 0 Then
                If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaDest.Text)) Then
                    MsgBox("Código de Cuenta no existente, Verifique")
                    txtCodCuentaDest.Text = ""
                    lblDesCuentaDest.Text = ""
                    txtCodCuentaDest.Focus()
                Else
                    Dim IdCuenta As Integer
                    IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                    Dim registro As New CuentaContableService.CuentaContable
                    registro = oCuentaContableService.Obtener(IdCuenta)
                    lblDesCuentaDest.Text = registro.NomCuenta
                    txtProveedor.Focus()
                End If
            Else
                txtProveedor.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCuentaDest_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCuentaDest.Validated
        If Len(Trim(txtCodCuentaDest.Text)) > 0 Then
            If Not (oCuentaContableService.BuscarCuenta(Session.sCodEmp, txtCodCuentaDest.Text)) Then
                MsgBox("Código de Cuenta no existente, Verifique")
                txtCodCuentaDest.Text = ""
                lblDesCuentaDest.Text = ""
                txtCodCuentaDest.Focus()
            Else
                Dim IdCuenta As Integer
                IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuentaDest.Text)
                Dim registro As New CuentaContableService.CuentaContable
                registro = oCuentaContableService.Obtener(IdCuenta)
                lblDesCuentaDest.Text = registro.NomCuenta
                txtProveedor.Focus()
            End If
        Else
            'txtNumJob.Focus()
        End If
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
                'If CodLibro = 31 Then
                'txtColaborador.Focus()
                'Else
                txtCodTipoDoc.Focus()
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    'If CodLibro = 31 Then
                    'txtColaborador.Focus()
                    'Else
                    txtCodTipoDoc.Focus()
                    'End If
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            'If CodLibro = 31 Then
            txtColaborador.Focus()
            'Else
            'txtCodTipoDoc.Focus()
            'End If
        End If
    End Sub

    Private Sub txtCodTipoDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodTipoDoc.Click
        txtCodTipoDoc.SelectAll()
    End Sub

    Private Sub txtCodTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            Try
                If Len(Trim(txtCodTipoDoc.Text)) > 0 Then
                    Dim cant As Integer = Len(txtCodTipoDoc.Text)
                    Do While cant < 2
                        txtCodTipoDoc.Text = "0" & txtCodTipoDoc.Text
                        cant = cant + 1
                    Loop

                    Dim IdDocumento As Integer
                    Dim TipoDoc As String = txtCodTipoDoc.Text
                    IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoDoc.Text)))
                    If IdDocumento <> 0 Then
                        cmbTipoDoc.Value = IdDocumento
                        txtCodTipoDoc.Text = TipoDoc
                        txtSerieDoc.Focus()
                    Else
                        MsgBox("Codigo no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                        cmbTipoDoc.SelectedIndex = 0
                        txtCodTipoDoc.Text = ""
                        txtCodTipoDoc.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtSerieDoc.Text)
                Do While cant < 4
                    txtSerieDoc.Text = "0" & txtSerieDoc.Text
                    cant = cant + 1
                Loop
                txtNumDoc.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US" Then
                    txtMontoDol.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtMontoSol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoSol.ValueChanged
        If Calcular Then
            If CodMon = "NS" Then
                txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
                'ElseIf CodMon = "US" Then
                '    txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
            End If
        End If
    End Sub

    Private Sub txtMontoDol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoDol.ValueChanged
        If Calcular Then
            'If CodMon = "NS" Then
            '    txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
            If CodMon = "US" Then
                txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
            End If
        End If
    End Sub


    Private Sub txtMontoDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtMontoSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub cmbTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtSerieDoc.Focus()
        End If
    End Sub

    Private Sub cmbTipoDoc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.ValueChanged
        txtCodTipoDoc.Text = IIf(cmbTipoDoc.Value = 0, "", cmbTipoDoc.DropDownList.GetRow.Cells(3).Text)
    End Sub

    '---------------------- Se agregó el 26/03/2014 (validando que solo se ingrese proveedor o Colaborador pero no ambos Sr. Jesus Alba) ------------------------
    Private Sub txtColaborador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColaborador.TextChanged
        If txtColaborador.Text <> "" Then
            btnAgregarProveedor.Enabled = False
            btnBuscarProveedor.Enabled = False
            IdProveedor = 0
            txtProveedor.Text = ""
        Else
            btnAgregarProveedor.Enabled = True
            btnBuscarProveedor.Enabled = True
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        If txtProveedor.Text <> "" Then
            btnBuscarPersona.Enabled = False
            IdPersona = 0
            txtColaborador.Text = ""
        Else
            btnBuscarPersona.Enabled = True
        End If
    End Sub
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Function ValidarMontos() As Boolean
        Try
            'If dgvDatos.RowCount > 0 Then
            '    Dim totalSoles As Double = 0
            '    Dim totalDolares As Double = 0
            '    Dim row As Janus.Windows.GridEX.GridEXRow
            '    For i = 0 To Me.dgvDatos.RowCount - 1
            '        Me.dgvDatos.Row = i
            '        row = Me.dgvDatos.GetRow()
            '        totalSoles = totalSoles + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoSol").Value)
            '        totalDolares = totalDolares + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoDol").Value)
            '    Next

            '    If txtMontoSol.Value = Math.Round(totalSoles, 2) And txtMontoDol.Value = Math.Round(totalDolares, 2) Then
            Return True
            '        'If CodMon = "NS" And txtMontoSol.Value = Math.Round(totalSoles, 2) Then
            '        '    Return True
            '        'ElseIf CodMon = "US" And txtMontoDol.Value = Math.Round(totalDolares, 2) Then
            '        '    Return True
            '    Else
            '        Return False
            '    End If

            'Else
            '    Return False
            'End If
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Function

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdCliente = frm.codigo
                    txtCliente.Text = frm.descripcion
                    'If CodLibro = 31 Then
                    'txtColaborador.Focus()
                    'Else
                    cmbTipoDoc.Focus()
                    'End If
                Else
                    IdProveedor = 0
                    txtCliente.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US" Then
                    txtMontoDol.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try

    End Sub
End Class