Imports System.ServiceModel
Public Class frmMotor

    '===========================Servicios====================================================
    Private oMotorService As New MotorService.MotorServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oModeloService As New ModelosProductoService.ModelosProductoServiceClient  'ModeloService.ModeloServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient

    '====================== Declaración de Variables =============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public codMer As String

    Public IdCliente As Integer
    Public iUbicacion As String
    Private dtRubro As DataTable
    Private dtModeloMer As DataTable
    Private dtSerie As DataTable
    Private dtUbicacion As DataTable
    Private dtFabricante As DataTable
    Private dtModeloEquipo As DataTable
    Private dtTipoEquipo As DataTable
    Private dtContacto As DataTable
    Private dtEquipos As DataTable

    Private Sub frmEquipo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            txtCliente.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nuevo motor"
            activar()
            cbActivo.Checked = True
            txtFecArranque.IsNullDate = True
            ' cmbRubroMot.Value = "06"
            txtCodMer.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmEquipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMotorService.Close()
            oMaestroService.Close()
            oMercaderiaService.Close()
            oModeloService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oMotorService.Abort()
            oMaestroService.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oMotorService.Abort()
            oMaestroService.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmEquipo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Function getRowNinguno(ByVal data As DataTable)
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
        Try
            fila(5) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(6) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(7) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(8) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(9) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Function getRowNinguno1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= RUBRO ================================================
            dtRubro = oMercaderiaService.MostrarRubroMotor().Tables(0)
            cmbRubroMot.DataSource = dtRubro
            cmbRubroMot.DropDownList.DataMember = dtRubro.Columns("DesRubMot").ToString
            cmbRubroMot.DropDownList.DisplayMember = dtRubro.Columns("DesRubMot").ToString
            cmbRubroMot.DropDownList.ValueMember = dtRubro.Columns("CodRubMot").ToString
            cmbRubroMot.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubMot").ToString
            cmbRubroMot.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubMot").ToString
            cmbRubroMot.SelectedIndex = 0
            dtRubro = Nothing

            '====================================== MODELOS ===============================================
            dtModeloMer = oModeloService.Mostrar(Session.sCodEmp).Tables(0)
            dtModeloMer.Rows.InsertAt(getRowNinguno1(dtModeloMer), 0)
            cmbModeloMer.DataSource = dtModeloMer
            cmbModeloMer.DropDownList.DataMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.DisplayMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.ValueMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(0).DataMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(1).DataMember = dtModeloMer.Columns("Descripcion").ToString
            cmbModeloMer.SelectedIndex = 0
            dtModeloMer = Nothing

            '======================================== SERIE =================================================
            dtSerie = oMotorService.MostrarSeries().Tables(0)
            cmbSerie.DataSource = dtSerie
            cmbSerie.DropDownList.DataMember = dtSerie.Columns("Descripcion").ToString
            cmbSerie.DropDownList.DisplayMember = dtSerie.Columns("Descripcion").ToString
            cmbSerie.DropDownList.ValueMember = dtSerie.Columns("CodSerie").ToString
            cmbSerie.DropDownList.Columns(0).DataMember = dtSerie.Columns("CodSerie").ToString
            cmbSerie.DropDownList.Columns(1).DataMember = dtSerie.Columns("Descripcion").ToString
            cmbSerie.SelectedIndex = 0
            dtSerie = Nothing

            '==================================== FABRICANTE =============================================
            dtFabricante = oMotorService.MostrarFabricanteEquipo().Tables(0)
            dtFabricante.Rows.InsertAt(getRowNinguno(dtFabricante), 0)
            cmbFabricante.DataSource = dtFabricante
            cmbFabricante.DropDownList.DataMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.DropDownList.DisplayMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.DropDownList.ValueMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(0).DataMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(1).DataMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.SelectedIndex = 0
            dtFabricante = Nothing


            '=================================== MODELO EQUIPO ========================================
            dtModeloEquipo = oMotorService.MostrarModeloEquipo(toNumber(0)).Tables(0)
            dtModeloEquipo.Rows.InsertAt(getRowNinguno1(dtModeloEquipo), 0)
            cmbModeloEquipo.DataSource = dtModeloEquipo
            cmbModeloEquipo.DropDownList.DataMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.DropDownList.DisplayMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.DropDownList.ValueMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(0).DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(1).DataMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.SelectedIndex = 0


            '===================================== TIPO EQUIPO ==============================================
            dtTipoEquipo = oMotorService.MostrarTipoEquipo().Tables(0)
            dtTipoEquipo.Rows.InsertAt(getRowNinguno(dtTipoEquipo), 0)
            cmbTipoEquipo.DataSource = dtTipoEquipo
            cmbTipoEquipo.DropDownList.DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.DisplayMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.ValueMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(0).DataMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(1).DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.SelectedIndex = 0
            dtTipoEquipo = Nothing





        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbFabricante_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFabricante.ValueChanged
        'Try

        '    '=================================== MODELO EQUIPO ========================================
        '    dtModeloEquipo = oMotorService.MostrarModeloEquipo(toNumber(cmbFabricante.Value)).Tables(0)
        '    dtModeloEquipo.Rows.InsertAt(getRowNinguno1(dtModeloEquipo), 0)
        '    cmbModeloEquipo.DataSource = dtModeloEquipo
        '    cmbModeloEquipo.DropDownList.DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.DisplayMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.ValueMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.Columns(0).DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.Columns(1).DataMember = dtModeloEquipo.Columns("Descripcion").ToString
        '    cmbModeloEquipo.SelectedIndex = 0

        'Catch ex As Exception
        '    MsgBox("ERROR AL LLENAR MODELO EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub


    Private Sub ListarContactos()
        Try
            cmbContactoCliente.DataSource = Nothing
            cmbContactoCliente.Text = ""
            cmbContactoCliente.Value = ""
            dtContacto = oContactoService.Mostrar(IdCliente).Tables(0)
            dtContacto.Rows.InsertAt(getRowNinguno(dtContacto), 0)
            If dtContacto.Rows.Count <> 0 Then
                '===================================== CONTACTOS ==============================================
                cmbContactoCliente.DataSource = dtContacto
                cmbContactoCliente.DropDownList.DataMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.DisplayMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.ValueMember = dtContacto.Columns("IdContacto").ToString
                cmbContactoCliente.DropDownList.Columns(0).DataMember = dtContacto.Columns("IdContacto").ToString
                cmbContactoCliente.DropDownList.Columns(1).DataMember = dtContacto.Columns("Apellidos").ToString
                cmbContactoCliente.DropDownList.Columns(2).DataMember = dtContacto.Columns("Nombres").ToString
                cmbContactoCliente.SelectedIndex = 0
                dtContacto = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS CONTACTOS" + ex.Message)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnioFab.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub activar()
        txtCodMer.ReadOnly = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        btnBuscarMercaderia.Enabled = True
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = True
        cmbContactoCliente.ReadOnly = False
        cmbContactoCliente.BackColor = System.Drawing.SystemColors.Window
        btnAgregarContacto.Enabled = True
        cmbUbicacion.ReadOnly = False
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
        cmbEquipos.ReadOnly = False
        cmbEquipos.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        btnBuscarJob.Enabled = True
        txtAnioFab.ReadOnly = False
        txtAnioFab.BackColor = System.Drawing.SystemColors.Window
        txtFecArranque.ReadOnly = False
        txtFecArranque.BackColor = System.Drawing.SystemColors.Window
        txtVendedor.ReadOnly = False
        txtVendedor.BackColor = System.Drawing.SystemColors.Window
        cmbRubroMot.ReadOnly = False
        cmbRubroMot.BackColor = System.Drawing.SystemColors.Window
        cmbFabricante.ReadOnly = False
        cmbFabricante.BackColor = System.Drawing.SystemColors.Window
        cmbModeloMer.ReadOnly = False
        cmbModeloMer.BackColor = System.Drawing.SystemColors.Window
        cmbSerie.ReadOnly = False
        cmbSerie.BackColor = System.Drawing.SystemColors.Window
        cmbModeloEquipo.ReadOnly = False
        cmbModeloEquipo.BackColor = System.Drawing.SystemColors.Window
        cmbTipoEquipo.ReadOnly = False
        cmbTipoEquipo.BackColor = System.Drawing.SystemColors.Window
        txtPotencia.ReadOnly = False
        txtPotencia.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        txtCodMer.Focus()
    End Sub

    Private Sub desactivar()
        txtCodMer.Enabled = False
        txtCodMer.BackColor = System.Drawing.SystemColors.Window
        btnBuscarMercaderia.Enabled = False
        txtCliente.ReadOnly = True
        txtCliente.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = True
        cmbContactoCliente.ReadOnly = False
        cmbContactoCliente.BackColor = System.Drawing.SystemColors.Window
        btnAgregarContacto.Enabled = True
        cmbUbicacion.ReadOnly = False
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Window
        cmbEquipos.ReadOnly = False
        cmbEquipos.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        btnBuscarJob.Enabled = True
        txtAnioFab.ReadOnly = False
        txtAnioFab.BackColor = System.Drawing.SystemColors.Window
        txtFecArranque.ReadOnly = False
        txtFecArranque.BackColor = System.Drawing.SystemColors.Window
        txtVendedor.ReadOnly = False
        txtVendedor.BackColor = System.Drawing.SystemColors.Window
        cmbRubroMot.ReadOnly = False
        cmbRubroMot.BackColor = System.Drawing.SystemColors.Window
        cmbFabricante.ReadOnly = False
        cmbFabricante.BackColor = System.Drawing.SystemColors.Window
        cmbModeloMer.ReadOnly = False
        cmbModeloMer.BackColor = System.Drawing.SystemColors.Window
        cmbSerie.ReadOnly = False
        cmbSerie.BackColor = System.Drawing.SystemColors.Window
        cmbModeloEquipo.ReadOnly = False
        cmbModeloEquipo.BackColor = System.Drawing.SystemColors.Window
        cmbTipoEquipo.ReadOnly = False
        cmbTipoEquipo.BackColor = System.Drawing.SystemColors.Window
        txtPotencia.ReadOnly = False
        txtPotencia.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        txtCliente.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtCodMer.Text = "" Then
                MsgBox("Debe Ingresar la Serie del Motor", MsgBoxStyle.Information, "Información")
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe seleccionar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
                Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe Ingresar la Ubicación.", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf txtAnioFab.Text <> "" And (utils.toNumber(txtAnioFab.Text) > 9999 Or utils.toNumber(txtAnioFab.Text) < 1000) Then
                MsgBox("El año de fabricación debe ser de 4 dígitos.", MsgBoxStyle.Information, "Información")
                txtAnioFab.Focus()
                Return False
            ElseIf toBlank(cmbRubroMot.Value) = "" Then
                MsgBox("Debe Ingresar el Rubro.", MsgBoxStyle.Information, "Información")
                cmbRubroMot.Focus()
                Return False
            ElseIf toBlank(cmbSerie.Value) = "" Then
                MsgBox("Debe Ingresar la Serie.", MsgBoxStyle.Information, "Información")
                cmbSerie.Focus()
                Return False
            ElseIf toNumber(txtPotencia.Value) < 1 Then
                MsgBox("La potencia del Motor debe ser mayor a cero.", MsgBoxStyle.Information, "Información")
                txtPotencia.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As MotorService.Motor
            registro = oMotorService.Obtener(codMer)

            codMer = registro.NumSerie
            txtCodMer.Text = registro.NumSerie
            'txtNombreEquipo.Text = registro.Equipo.NomEquipo
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            ListarContactos()
            If registro.Contacto.IdContacto.ToString = "" Then
                cmbContactoCliente.SelectedIndex = 0
            Else
                cmbContactoCliente.Value = registro.Contacto.IdContacto
            End If
            cbActivo.Checked = registro.Activo
            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion            
            If toBlank(registro.Equipo.CodEquipo) = "" Then
                cmbEquipos.SelectedIndex = 0
            Else
                cmbEquipos.Value = registro.Equipo.CodEquipo
            End If
            txtNumJob.Text = registro.Job.CodJob
            txtAnioFab.Text = registro.AnioFab.ToString
            If Not (registro.FecArranque.ToString = "") Then
                txtFecArranque.IsNullDate = False
                txtFecArranque.Value = CDate(registro.FecArranque)
                txtFecArranque.Text = registro.FecArranque.ToString
            Else
                txtFecArranque.IsNullDate = True
            End If
            txtVendedor.Text = registro.Vendedor
            cmbRubroMot.Value = registro.RubroMotor.CodRubMot
            If toBlank(registro.Modelo.ModMer) = "" Then
                cmbModeloMer.SelectedIndex = 0
            Else
                cmbModeloMer.Value = registro.Modelo.ModMer
            End If
            cmbSerie.Value = registro.Serie.CodSerie
            txtPotencia.Value = registro.Potencia
            If registro.FabricanteEquipo.IdFabricante.ToString = "" Then
                cmbFabricante.SelectedIndex = 0
            Else
                cmbFabricante.Value = registro.FabricanteEquipo.IdFabricante
            End If
            If toBlank(registro.ModeloEquipo.ModEquipo) = "" Then
                cmbModeloEquipo.SelectedIndex = 0
            Else
                cmbModeloEquipo.Value = registro.ModeloEquipo.ModEquipo
            End If
            If registro.TipoEquipo.IdTipo.ToString = "" Then
                cmbTipoEquipo.SelectedIndex = 0
            Else
                cmbTipoEquipo.Value = registro.TipoEquipo.IdTipo
            End If
            txtCapacidad.Text = registro.Capacidad
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As MotorService.Motor)
        Try
            Dim estado_process As String
            estado_process = oMotorService.Insertar(registro)
            type_process = "insert"
            If estado_process <> "" Then
                codMer = estado_process
                iUbicacion = cmbUbicacion.Value
                MsgBox("Se insertó el Equipo Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MotorService.Motor)
        Try
            Dim estado_process As Boolean
            estado_process = oMotorService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oMotorService.Borrar(codMer, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                    ListarContactos()
                Else
                    txtCliente.Text = ""
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtBuscarCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        Try
            If IdCliente > 0 Then
                Dim frm As New frmAgregarContacto
                frm.IdCliente = IdCliente
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListarContactos()
                    cmbContactoCliente.Select()
                    cmbContactoCliente.DroppedDown = True
                End If
            Else
                MsgBox("Debe ingresar el Cliente")
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el contacto : " + ex.Message, MsgBoxStyle.Exclamation)
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
                    txtAnioFab.Focus()
                End If
            Else
                txtAnioFab.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtAnioFab.Focus()
                End If
            Else
                txtAnioFab.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMercaderia
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtCodMer.Text = frm.codigo
                DatosMercaderia()
                txtCliente.Focus()
            End If
            'txtCodMer.Select()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER MERCADERÍA : " + ex.Message)
        End Try
    End Sub

    Private Sub DatosMercaderia()
        Try
            If oMercaderiaService.Buscar(Trim(txtCodMer.Text), Session.sCodEmp) Then
                Dim mercaderia As New ProductoService.Producto  'MercaderiaService.Mercaderia
                mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                If mercaderia.RubroMotor.CodRubMot <> "" Then
                    cmbRubroMot.Value = mercaderia.RubroMotor.CodRubMot
                End If
                If mercaderia.Modelo.ModMer <> "" Then
                    cmbModeloMer.Value = mercaderia.Modelo.ModMer
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS DE MERCADERÍA : " + ex.Message)
        End Try
    End Sub

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                e.Handled = True
                btnBuscarMercaderia_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        DatosMercaderia()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim registro As New MotorService.Motor
                    Dim Empresa As New MotorService.Empresa
                    Dim Cliente As New MotorService.Cliente
                    Dim Contacto As New MotorService.Contacto
                    Dim Ubicacion As New MotorService.UbicacionEquipo
                    Dim Job As New MotorService.Job
                    Dim Rubro As New MotorService.RubroMotor
                    Dim Modelo As New MotorService.Modelo
                    Dim Serie As New MotorService.Serie
                    Dim FabricanteEquipo As New MotorService.FabricanteEquipo
                    Dim ModeloEquipo As New MotorService.ModeloEquipo
                    Dim TipoEquipo As New MotorService.TipoEquipo
                    Dim Equipo As New MotorService.Equipo

                    Empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = Empresa

                    registro.NumSerie = txtCodMer.Text

                    Cliente.IdCliente = IdCliente
                    registro.Cliente = Cliente

                    If cmbContactoCliente.SelectedIndex = 0 Then
                        Contacto.IdContacto = Nothing
                        registro.Contacto = Contacto
                    Else
                        Contacto.IdContacto = toNumber(cmbContactoCliente.Value)
                        registro.Contacto = Contacto
                    End If
                    registro.Activo = cbActivo.Checked
                    Ubicacion.CodUbicacion = cmbUbicacion.Value
                    registro.UbicacionEquipo = Ubicacion

                    Equipo.CodEquipo = IIf(cmbEquipos.SelectedIndex = 0, Nothing, cmbEquipos.Value)
                    Equipo.NomEquipo = txtNombreEquipo.Text
                    registro.Equipo = Equipo

                    Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                    registro.Job = Job
                    registro.AnioFab = IIf(txtAnioFab.Text = "", Nothing, toNumber(txtAnioFab.Text))
                    registro.FecArranque = IIf(txtFecArranque.Text = "", Nothing, txtFecArranque.Value)
                    registro.Vendedor = txtVendedor.Text
                    Rubro.CodRubMot = cmbRubroMot.Value
                    registro.RubroMotor = Rubro
                    Modelo.ModMer = IIf(cmbModeloMer.SelectedIndex = 0, Nothing, cmbModeloMer.Value)
                    registro.Modelo = Modelo
                    Serie.CodSerie = cmbSerie.Value
                    registro.Serie = Serie
                    registro.Potencia = txtPotencia.Value
                    FabricanteEquipo.IdFabricante = IIf(cmbFabricante.SelectedIndex = 0, Nothing, toNumber(cmbFabricante.Value))
                    registro.FabricanteEquipo = FabricanteEquipo
                    ModeloEquipo.ModEquipo = IIf(cmbModeloEquipo.SelectedIndex = 0, Nothing, cmbModeloEquipo.Value)
                    registro.ModeloEquipo = ModeloEquipo
                    TipoEquipo.IdTipo = IIf(cmbTipoEquipo.SelectedIndex = 0, Nothing, toNumber(cmbTipoEquipo.Value))
                    registro.TipoEquipo = TipoEquipo
                    registro.Capacidad = txtCapacidad.Text
                    registro.Observacion = txtObservacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.NomPc = Session.sNomPc

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR MOTOR:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtCodMer.KeyPress _
                         , txtCliente.KeyPress _
                         , cmbContactoCliente.KeyPress _
                         , cmbUbicacion.KeyPress _
                         , cmbEquipos.KeyPress _
                         , cbActivo.KeyPress _
                         , txtAnioFab.KeyPress _
                         , txtFecArranque.KeyPress _
                         , txtVendedor.KeyPress _
                         , cmbRubroMot.KeyPress _
                         , cmbModeloMer.KeyPress _
                         , cmbSerie.KeyPress _
                         , cmbModeloEquipo.KeyPress _
                         , cmbTipoEquipo.KeyPress _
                         , txtPotencia.KeyPress _
                         , cmbFabricante.KeyPress _
                         , txtCapacidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtAnioFab.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub cmbUbicacion_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbUbicacion.ValueChanged
        Try

            '=================================== EQUIPOS ========================================
            dtEquipos = oMotorService.MostrarEquipos(toNumber(cmbUbicacion.Value)).Tables(0)
            dtEquipos.Rows.InsertAt(getRowNinguno(dtEquipos), 0)
            cmbEquipos.DataSource = dtEquipos
            cmbEquipos.DropDownList.DataMember = dtEquipos.Columns("CodEquipo").ToString
            cmbEquipos.DropDownList.DisplayMember = dtEquipos.Columns("CodEquipo").ToString
            cmbEquipos.DropDownList.ValueMember = dtEquipos.Columns("CodEquipo").ToString
            cmbEquipos.DropDownList.Columns(0).DataMember = dtEquipos.Columns("CodEquipo").ToString
            cmbEquipos.DropDownList.Columns(1).DataMember = dtEquipos.Columns("NomEquipo").ToString
            cmbEquipos.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR EQUIPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbEquipos_ValueChanged(sender As Object, e As System.EventArgs) Handles cmbEquipos.ValueChanged, cmbUbicacion.ValueChanged
        If cmbEquipos.SelectedIndex = 0 Then
            txtNombreEquipo.Text = ""
        Else
            txtNombreEquipo.Text = oMotorService.ObtenerNombreEquipo(toBlank(cmbUbicacion.Value), toBlank(cmbEquipos.Value))
        End If
    End Sub


End Class