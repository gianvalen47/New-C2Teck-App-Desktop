Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmFlujoCajaDetalle

    '===========================Servicios====================================================

    Private oFlujoCajaDetService As New FlujoCajaDetService.FlujoCajaDetServiceClient


    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable
    Public IdFlujoCaja As Integer
    Public IdTipo As Integer
    Private dtConcepto As DataTable
    Public IdEstado As Integer



    Private Sub frmActivoFijo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgvDatos)
        'dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        'dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left


        txtIdFlujoCaja.Text = IdFlujoCaja
        llenarcombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            Desactivar()

            'gbDetalles.Visible = True



            Me.Text = "Flujo de Caja Detalle"
            ' dgvDatos.Select()
            txtMontoInicio.Focus()
            txtMontoInicio.Select()
        Else                          'Nuevo
            'Me.Size = New System.Drawing.Size(659, 400)

            'gbDetalles.Visible = False



            Me.Text = "Registrar nuevo detalle Flujo de Caja"
            Activar()
            txtMontoInicio.Focus()
        End If

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                   txtIdFlujoCaja.KeyPress _
 _
 _
 _
 _
 _
 _
                 , cmbConcepto.KeyPress _
 _
 _
 _
 _
                 , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmActivoFijo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVehiculo_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try

            oFlujoCajaDetService.Close()

        Catch ex As TimeoutException

            oFlujoCajaDetService.Abort()

        Catch ex As CommunicationException

            oFlujoCajaDetService.Abort()

        End Try
    End Sub





    Private Sub llenarcombos()
        Try

            '===================================== CONCEPTOS ===============================================
            dtConcepto = oFlujoCajaDetService.MostrarConceptosFlujoCaja(Session.sCodEmp).Tables(0)
            cmbConcepto.DataSource = dtConcepto
            cmbConcepto.DropDownList.DataMember = dtConcepto.Columns("DesTipo").ToString
            cmbConcepto.DropDownList.DisplayMember = dtConcepto.Columns("DesTipo").ToString
            cmbConcepto.DropDownList.ValueMember = dtConcepto.Columns("IdTipo").ToString
            cmbConcepto.DropDownList.Columns(0).DataMember = dtConcepto.Columns("IdTipo").ToString
            cmbConcepto.DropDownList.Columns(1).DataMember = dtConcepto.Columns("DesTipo").ToString
            cmbConcepto.SelectedIndex = 0
            dtConcepto = Nothing


        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub





    Protected Sub Activar()
        Try
            If state_button Then   'Actualizar
                'txtIdFlujoCaja.ReadOnly = True
                'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control

                txtMontoInicio.ReadOnly = False
                txtMontoInicio.BackColor = System.Drawing.SystemColors.Window

                cmbConcepto.ReadOnly = False
                cmbConcepto.BackColor = System.Drawing.SystemColors.Window


                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                edicion = True

                txtObservacion.Focus()

            Else                       'Nuevo
                'txtIdFlujoCaja.ReadOnly = False
                'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Window

                txtMontoInicio.ReadOnly = False
                txtMontoInicio.BackColor = System.Drawing.SystemColors.Window

                cmbConcepto.ReadOnly = False
                cmbConcepto.BackColor = System.Drawing.SystemColors.Window


                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window

                edicion = True

                txtMontoInicio.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try

            If IdEstado = 1 Then
                'txtIdFlujoCaja.ReadOnly = True
                'txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control

                cmbConcepto.ReadOnly = True
                cmbConcepto.BackColor = System.Drawing.SystemColors.Control

                txtMontoInicio.ReadOnly = False
                txtMontoInicio.BackColor = System.Drawing.SystemColors.Window




                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
            Else
                txtMontoInicio.ReadOnly = True
                txtMontoInicio.BackColor = System.Drawing.SystemColors.Control

                cmbConcepto.ReadOnly = True
                cmbConcepto.BackColor = System.Drawing.SystemColors.Control


                txtObservacion.ReadOnly = True
                txtObservacion.BackColor = System.Drawing.SystemColors.Control
                biGuardar.Enabled = False
            End If

            edicion = False

            txtMontoInicio.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtIdFlujoCaja.Text) = "" Then
                MsgBox("Debe ingresar el código del Flujo", MsgBoxStyle.Information, "Información")
                txtIdFlujoCaja.Focus()
                Return False
                'ElseIf toBlank(txtObservacion.Text) = "" Then
                '    MsgBox("Debe ingresar la descripción del Flujo", MsgBoxStyle.Information, "Información")
                '    txtObservacion.Focus()
                '    Return False

            ElseIf toNull(txtMontoInicio.Text) = 0 Then
                MsgBox("Debe ingresar la Fecha de Inicio", MsgBoxStyle.Information, "Información")
                txtMontoInicio.Focus()
                Return False


            ElseIf toBlank(cmbConcepto.Value) = "" Then
                MsgBox("Debe ingresar el concepto", MsgBoxStyle.Information, "Información")
                cmbConcepto.Focus()
                Return False

            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
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



    Protected Sub ObtenerRegistro()
        Try

            Dim registro As FlujoCajaDetService.FlujoCajaDet
            registro = oFlujoCajaDetService.Obtener(IdFlujoCaja, IdTipo, Session.sCodEmp)

            IdFlujoCaja = registro.FlujoCajaCab.IdFlujoCaja
            txtIdFlujoCaja.Text = registro.FlujoCajaCab.IdFlujoCaja

            txtMontoInicio.Text = registro.Monto

            cmbConcepto.Value = registro.ConceptosFlujoCaja.IdTipo



            txtObservacion.Text = registro.Observacion



        Catch ex As Exception
            MsgBox("ERROR AL OBTENER DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Insertar(ByVal registro As FlujoCajaDetService.FlujoCajaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oFlujoCajaDetService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                IdFlujoCaja = txtIdFlujoCaja.Text
                MsgBox("Se insertó el concepto de flujo de caja Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR FLUJO DE CAJA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As FlujoCajaDetService.FlujoCajaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oFlujoCajaDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó el Flujo de Caja Correctamente")
                Desactivar()
                ObtenerRegistro()

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR FLUJO DE CAJA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub




    Protected Sub Guardar()
        Try
            If ValidaCampos() Then
                Dim registro As New FlujoCajaDetService.FlujoCajaDet

                Dim flujocaja As New FlujoCajaDetService.FlujoCajaCab
                Dim empresa As New FlujoCajaDetService.Empresa
                Dim tipo As New FlujoCajaDetService.ConceptosFlujoCaja

                flujocaja.IdFlujoCaja = IdFlujoCaja
                registro.FlujoCajaCab = flujocaja
                tipo.IdTipo = cmbConcepto.Value
                registro.ConceptosFlujoCaja = tipo
                empresa.CodEmp = Session.sCodEmp
                registro.ConceptosFlujoCaja.Empresa = empresa
                registro.Monto = txtMontoInicio.Text

                registro.Observacion = toBlank(txtObservacion.Text)
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecModifica = Today()

                If state_button = True Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Desactivar()
                ObtenerRegistro()

        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub


End Class