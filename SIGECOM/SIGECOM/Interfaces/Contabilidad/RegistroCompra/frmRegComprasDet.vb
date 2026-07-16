Imports System.ServiceModel
Public Class frmRegComprasDet

    '===========================Servicios====================================
    Private oJobService As New JobService.JobServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient
    'Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient
    Private oRegistroCompraDetService As New RegistroCompraDetService.RegistroCompraDetServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public IdCompraDet As Integer
    Public IdCompra As Integer
    Public CodMon As String
    Public AfectoIgv As Boolean
    Public TipoCambio As Double
    Public Igv As Double

    Private dtDatos As DataTable
    Public iSolicitud As Boolean               'Valor que devuelve el método BuscarSolicitud de oRegistroCompraDetService

    Private Calcular As Boolean = True

    Private Sub frmRegComprasDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        lblDesCuenta.Text = ""
        If state_button Then    'Modificar
            Calcular = False
            ObtenerRegistro()
            Calcular = True
            Desactivar()
            gbCentroCosto.Visible = True
            actualizarDetalles()
            Me.Text = "Registro de Compra Detalle"
            biAsignar.Focus()
        Else                          'Nuevo
            Calcular = True
            Me.Size = New System.Drawing.Size(575, 314)
            gbCentroCosto.Visible = False
            Me.Text = "Registrar nuevo Registro de Compra Detalle"
            Activar()
        End If        
        txtCodCuenta.Focus()
    End Sub

    Private Sub frmRegComprasDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmRegComprasDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
            'oMaestroService.Close()
            'oPersonaService.Close()
            oCuentaContableService.Close()
            oRegistroCompraService.Close()
            oRegistroCompraDetService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            'oMaestroService.Abort()
            'oPersonaService.Abort()
            oCuentaContableService.Abort()
            oRegistroCompraService.Abort()
            oRegistroCompraDetService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            'oMaestroService.Abort()
            'oPersonaService.Abort()            
            oCuentaContableService.Abort()
            oRegistroCompraService.Abort()
            oRegistroCompraDetService.Abort()
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

    Private Sub llenarCombos()
        Try

            ''========================================== AREAS ===============================================
            'dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
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

    'Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Protected Sub Activar()
        Try
            If state_button Then    'Actualizar
                'If iSolicitud Then        'Se comenta ya que el Sr. Jesus desea modificar los detalles de un registro de compra que venga de una Solicitud de Gasto
                '    txtCodCuenta.ReadOnly = True
                '    txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
                '    btnBuscarCuenta.Enabled = False
                '    txtNumJob.ReadOnly = True
                '    txtNumJob.BackColor = System.Drawing.SystemColors.Control
                '    btnBuscarJob.Enabled = False
                ''    cmbArea.ReadOnly = True
                ''    cmbArea.BackColor = System.Drawing.SystemColors.Control
                ''    cmbCentroCosto.ReadOnly = True
                ''    cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control

                '    txtMontoSol.ReadOnly = True
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvSol.ReadOnly = True
                '    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoSol.ReadOnly = True
                '    txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Control

                '    txtMontoDol.ReadOnly = True
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvDol.ReadOnly = True
                '    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoDol.ReadOnly = True
                '    txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Control

                '    txtObservacion.ReadOnly = False
                '    txtObservacion.BackColor = System.Drawing.SystemColors.Window
                'Else

                txtCodCuenta.ReadOnly = False
                txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
                btnBuscarCuenta.Enabled = True
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True

                '-------- Se agregó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos --------
                txtMontoSol.ReadOnly = False
                txtMontoSol.BackColor = System.Drawing.SystemColors.Window               
                txtMontoNoAfectoSol.ReadOnly = False
                txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Window

                txtMontoDol.ReadOnly = False
                txtMontoDol.BackColor = System.Drawing.SystemColors.Window                
                txtMontoNoAfectoDol.ReadOnly = False
                txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Window

                If AfectoIgv = True Then
                    txtMontoIgvSol.ReadOnly = False
                    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Window
                    txtMontoIgvDol.ReadOnly = False
                    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Window
                Else
                    txtMontoIgvSol.ReadOnly = True
                    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
                    txtMontoIgvDol.ReadOnly = True
                    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
                End If
                '--------------------------------------------------------------------------------------------------------------------------------

                '------ Se comentó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos ------
                'If CodMon = "NS" Then
                '    txtMontoSol.ReadOnly = False
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoIgvSol.ReadOnly = False
                '    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoNoAfectoSol.ReadOnly = False
                '    txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoDol.ReadOnly = True
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvDol.ReadOnly = True
                '    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoDol.ReadOnly = True
                '    txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Control
                'ElseIf CodMon = "US" Then
                '    txtMontoDol.ReadOnly = False
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoIgvDol.ReadOnly = False
                '    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoNoAfectoDol.ReadOnly = False
                '    txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoSol.ReadOnly = True
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvSol.ReadOnly = True
                '    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoSol.ReadOnly = True
                '    txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Control
                'End If
                '--------------------------------------------------------------------------------------------------------------------------------
                'End If

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

                '-------- Se agregó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos --------
                txtMontoSol.ReadOnly = False
                txtMontoSol.BackColor = System.Drawing.SystemColors.Window
                txtMontoNoAfectoSol.ReadOnly = False
                txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Window

                txtMontoDol.ReadOnly = False
                txtMontoDol.BackColor = System.Drawing.SystemColors.Window
                txtMontoNoAfectoDol.ReadOnly = False
                txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Window

                If AfectoIgv = True Then
                    txtMontoIgvSol.ReadOnly = False
                    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Window
                    txtMontoIgvDol.ReadOnly = False
                    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Window
                Else
                    txtMontoIgvSol.ReadOnly = True
                    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
                    txtMontoIgvDol.ReadOnly = True
                    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
                End If
                '--------------------------------------------------------------------------------------------------------------------------------

                '------ Se comentó el 06/08/2014 Sr Jesus Alba para que pueda modificar los montos ------
                'If CodMon = "NS" Then
                '    txtMontoSol.ReadOnly = False
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoIgvSol.ReadOnly = False
                '    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoNoAfectoSol.ReadOnly = False
                '    txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoDol.ReadOnly = True
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvDol.ReadOnly = True
                '    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoDol.ReadOnly = True
                '    txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Control
                'ElseIf CodMon = "US" Then
                '    txtMontoDol.ReadOnly = False
                '    txtMontoDol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoIgvDol.ReadOnly = False
                '    txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Window
                '    txtMontoNoAfectoDol.ReadOnly = False
                '    txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Window

                '    txtMontoSol.ReadOnly = True
                '    txtMontoSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoIgvSol.ReadOnly = True
                '    txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
                '    txtMontoNoAfectoSol.ReadOnly = True
                '    txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Control
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

    Protected Sub Desactivar()
        Try
            txtCodCuenta.ReadOnly = True
            txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
            btnBuscarCuenta.Enabled = False
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            btnBuscarJob.Enabled = False

            txtMontoSol.ReadOnly = True
            txtMontoSol.BackColor = System.Drawing.SystemColors.Control
            txtMontoIgvSol.ReadOnly = True
            txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfectoSol.ReadOnly = True
            txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Control

            txtMontoDol.ReadOnly = True
            txtMontoDol.BackColor = System.Drawing.SystemColors.Control
            txtMontoIgvDol.ReadOnly = True
            txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfectoDol.ReadOnly = True
            txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Control

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
            ElseIf CodMon = "NS" And toDouble(txtMontoSol.Value) < 0 Then
                MsgBox("El Monto Soles no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoSol.Focus()
                Return False
            ElseIf CodMon = "NS" And toDouble(txtMontoIgvSol.Value) < 0 Then
                MsgBox("El Monto IGV Soles no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoIgvSol.Focus()
                Return False
            ElseIf CodMon = "NS" And toDouble(txtMontoNoAfectoSol.Value) < 0 Then
                MsgBox("El Monto no afecto Soles no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoNoAfectoSol.Focus()
                Return False
            ElseIf CodMon = "NS" And (txtMontoSol.Value + txtMontoNoAfectoSol.Value) <= 0 Then
                MsgBox("El Monto Total debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoSol.Focus()
                Return False
            ElseIf CodMon = "US" And toDouble(txtMontoDol.Value) < 0 Then
                MsgBox("El Monto Dolares no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoDol.Focus()
                Return False
            ElseIf CodMon = "US" And toDouble(txtMontoIgvDol.Value) < 0 Then
                MsgBox("El Monto IGV Dolares no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoIgvDol.Focus()
                Return False
            ElseIf CodMon = "US" And toDouble(txtMontoNoAfectoDol.Value) < 0 Then
                MsgBox("El Monto no afecto Dolares no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoNoAfectoDol.Focus()
                Return False
            ElseIf CodMon = "US" And (txtMontoDol.Value + txtMontoNoAfectoDol.Value) <= 0 Then
                MsgBox("El Monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
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
            Dim registro As RegistroCompraDetService.RegistroCompraDet
            registro = oRegistroCompraDetService.Obtener(IdCompraDet)

            IdCompraDet = registro.IdCompraDet
            IdCompra = registro.RegistroCompra.IdCompra
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)
            lblDesCuenta.Text = Trim(registro.CuentaContable.NomCuenta)
            txtNumJob.Text = registro.Job.CodJob
            'cmbArea.Value = registro.CentroCosto.Area.CodArea
            'cmbCentroCosto.Value = registro.CentroCosto.CodCentro

            txtMontoSol.Value = registro.MontoSol
            txtMontoIgvSol.Value = registro.MontoIgvSol
            txtMontoNoAfectoSol.Value = registro.MontoNoAfectoSol
            txtTotalFilaSol.Value = registro.TotalFilaSol

            txtMontoDol.Value = registro.MontoDol
            txtMontoIgvDol.Value = registro.MontoIgvDol
            txtMontoNoAfectoDol.Value = registro.MontoNoAfectoDol
            txtTotalFilaDol.Value = registro.TotalFilaDol

            txtObservacion.Text = registro.Observacion
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmAgregar_CentroCosto_RegCom
            frm.IdCompraDet = IdCompraDet
            frm.IdCompra = IdCompra
            frm.MontoSoles = txtMontoSol.Value
            frm.MontoIgvSol = txtMontoIgvSol.Value
            frm.MontoNoAfectoSol = txtMontoNoAfectoSol.Value
            frm.TotalSoles = txtTotalFilaSol.Value

            frm.MontoDolares = txtMontoDol.Value
            frm.MontoIgvDol = txtMontoIgvDol.Value
            frm.MontoNoAfectoDol = txtMontoNoAfectoDol.Value
            frm.TotalDolares = txtTotalFilaDol.Value

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

    Private Sub Insertar(ByVal registro As RegistroCompraDetService.RegistroCompraDet)
        Try
            Dim estado_process As Integer
            estado_process = oRegistroCompraDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCompraDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RegistroCompraDetService.RegistroCompraDet)
        Try
            Dim estado_process As Boolean
            estado_process = oRegistroCompraDetService.Actualizar(registro)
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
            dtDatos = oRegistroCompraDetService.MostrarCentroCosto(IdCompraDet).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Guardar()
        Try            
            If ValidaCampos() Then
                Dim registro As New RegistroCompraDetService.RegistroCompraDet
                Dim RegistroCompra As New RegistroCompraDetService.RegistroCompra
                Dim CuentaContable As New RegistroCompraDetService.CuentaContable
                'Dim CentroCosto As New RegistroCompraDetService.CentroCosto
                'Dim Area As New RegistroCompraDetService.Area
                Dim Job As New RegistroCompraDetService.Job

                registro.IdCompraDet = IdCompraDet
                RegistroCompra.IdCompra = IdCompra
                registro.RegistroCompra = RegistroCompra
                CuentaContable.IdCuenta = oCuentaContableService.ObtenerIdCuenta(Session.sCodEmp, txtCodCuenta.Text)
                CuentaContable.CodCuenta = txtCodCuenta.Text
                registro.CuentaContable = CuentaContable
                Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                registro.Job = Job
                'Area.CodArea = cmbArea.Value
                'CentroCosto.CodCentro = cmbCentroCosto.Value
                'CentroCosto.Area = Area
                'registro.CentroCosto = CentroCosto

                registro.MontoSol = txtMontoSol.Value
                registro.MontoIgvSol = txtMontoIgvSol.Value
                registro.MontoNoAfectoSol = txtMontoNoAfectoSol.Value
                registro.TotalFilaSol = txtTotalFilaSol.Value

                registro.MontoDol = txtMontoDol.Value
                registro.MontoIgvDol = txtMontoIgvDol.Value
                registro.MontoNoAfectoDol = txtMontoNoAfectoDol.Value
                registro.TotalFilaDol = txtTotalFilaDol.Value

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
            MsgBox("ERROR AL GUARDAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
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
        'If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then   --Sr. Jesus Alba
        Guardar()
        'End If
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
                    If CodMon = "NS" Then
                        txtMontoSol.Focus()
                    ElseIf CodMon = "US" Then
                        txtMontoDol.Focus()
                    End If
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
                    If CodMon = "NS" Then
                        txtMontoSol.Focus()
                    ElseIf CodMon = "US" Then
                        txtMontoDol.Focus()
                    End If
                End If
            Else
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US" Then
                    txtMontoDol.Focus()
                End If
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
                    If CodMon = "NS" Then
                        txtMontoSol.Focus()
                    ElseIf CodMon = "US" Then
                        txtMontoDol.Focus()
                    End If
                End If
            Else
                If CodMon = "NS" Then
                    txtMontoSol.Focus()
                ElseIf CodMon = "US" Then
                    txtMontoDol.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    'Private Sub cmbArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        cmbCentroCosto.Focus()
    '    End If
    'End Sub

    'Private Sub cmbCentroCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
    '        e.Handled = True
    '        If CodMon = "NS" Then
    '            txtMontoSol.Focus()
    '        ElseIf CodMon = "US" Then
    '            txtMontoDol.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub txtMontoSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoIgvSol.Focus()
        End If
    End Sub

    Private Sub txtMontoIgvSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoIgvSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoNoAfectoSol.Focus()
        End If
    End Sub

    Private Sub txtMontoNoAfectoSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoNoAfectoSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtMontoDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoIgvDol.Focus()
        End If
    End Sub

    Private Sub txtMontoIgvDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoIgvDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMontoNoAfectoDol.Focus()
        End If
    End Sub

    Private Sub txtMontoNoAfectoDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoNoAfectoDol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtMontoDol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoDol.ValueChanged
        If Calcular = True Then
            'If CodMon = "NS" Then
            '    If AfectoIgv = True Then
            '        txtMontoIgvSol.Value = txtMontoSol.Value * (Igv / 100)
            '    End If
            '    txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
            If CodMon = "US" Then
                If AfectoIgv = True Then
                    txtMontoIgvDol.Value = txtMontoDol.Value * (Igv / 100)
                End If
                txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoSol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoSol.ValueChanged
        If Calcular = True Then
            If CodMon = "NS" Then
                If AfectoIgv = True Then
                    txtMontoIgvSol.Value = txtMontoSol.Value * (Igv / 100)
                End If
                txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
                'ElseIf CodMon = "US" Then
                '    If AfectoIgv = True Then
                '        txtMontoIgvDol.Value = txtMontoDol.Value * (Igv / 100)
                '    End If
                '    txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
            End If
            txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            'txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoIgvSol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoIgvSol.ValueChanged
        If Calcular = True Then
            If CodMon = "NS" Then
                txtMontoIgvDol.Value = Math.Round((txtMontoIgvSol.Value / TipoCambio), 2)
                'ElseIf CodMon = "US" Then
                '    txtMontoIgvSol.Value = Math.Round((txtMontoIgvDol.Value * TipoCambio), 2)
            End If
            txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            'txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoIgvDol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoIgvDol.ValueChanged
        If Calcular = True Then
            'If CodMon = "NS" Then
            '    txtMontoIgvDol.Value = Math.Round((txtMontoIgvSol.Value / TipoCambio), 2)
            If CodMon = "US" Then
                txtMontoIgvSol.Value = Math.Round((txtMontoIgvDol.Value * TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoNoAfectoDol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoNoAfectoDol.ValueChanged
        If Calcular = True Then
            'If CodMon = "NS" Then
            '    txtMontoNoAfectoDol.Value = Math.Round((txtMontoNoAfectoSol.Value / TipoCambio), 2)
            If CodMon = "US" Then
                txtMontoNoAfectoSol.Value = Math.Round((txtMontoNoAfectoDol.Value * TipoCambio), 2)
            End If
            'txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
    End Sub

    Private Sub txtMontoNoAfectoSol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoNoAfectoSol.ValueChanged
        If Calcular = True Then
            If CodMon = "NS" Then
                txtMontoNoAfectoDol.Value = Math.Round((txtMontoNoAfectoSol.Value / TipoCambio), 2)
                'ElseIf CodMon = "US" Then
                '    txtMontoNoAfectoSol.Value = Math.Round((txtMontoNoAfectoDol.Value * TipoCambio), 2)
            End If
            txtTotalFilaSol.Value = txtMontoSol.Value + txtMontoIgvSol.Value + txtMontoNoAfectoSol.Value
            'txtTotalFilaDol.Value = txtMontoDol.Value + txtMontoIgvDol.Value + txtMontoNoAfectoDol.Value
        End If
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


End Class