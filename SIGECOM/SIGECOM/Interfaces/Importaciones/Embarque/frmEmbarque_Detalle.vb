Imports System.ServiceModel
Public Class frmEmbarque_Detalle

    '============================ Servicios ===================================
    Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient
    Private oFacturaImportDetService As New FacturaImportDetService.FacturaImportDetServiceClient
    '====================== Declaración de Variables ==============================
    Public state_button As Boolean          'True: modificar    False: nuevo
    Public type_process As String            'update     insert      delete    
    Public CodEmbarque As String
    Public IdFactura As String
    Public iEstado As Integer
    Private dtDatos As New DataTable

    Private Sub frmEmbarque_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmEmbarque_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.CancelButton = Me.btnCancelar
        llenarCombos()        

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()            
            txtNroPqte.Focus()
        Else                                      'Nuevo
            activar()            
            txtNroPqte.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmHoraExtra_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oEmbarqueDetService.Close()
            oFacturaImportDetService.Close()
        Catch ex As TimeoutException
            oEmbarqueDetService.Abort()
            oFacturaImportDetService.Abort()
        Catch ex As CommunicationException
            oEmbarqueDetService.Abort()
            oFacturaImportDetService.Abort()
        End Try
    End Sub

    Private Sub EnableOptions()
        If iEstado = 1 Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        txtNroPqte.ReadOnly = False
        txtNroPqte.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        If iEstado = 1 Then
            txtNroPqte.ReadOnly = False
            txtNroPqte.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnGuardar.Enabled = True
        Else
            txtNroPqte.ReadOnly = True
            txtNroPqte.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(CodEmbarque) = "" Then
                MsgBox("El Código de Embarque no es valido.", MsgBoxStyle.Information, "Información")                
                Return False
            ElseIf toNumber(IdFactura) = 0 Then
                MsgBox("El Número de Factura no es valido.", MsgBoxStyle.Information, "Información")                
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Insertar(ByVal registro As EmbarqueDetService.EmbarqueDet)
        Try
            'Dim estado_process As Boolean
            'estado_process = oEmbarqueDetService.Insertar(registro)
            'type_process = "insert"
            'If estado_process > 0 Then
            '    IdFactura = IdFactura
            '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
            'Else
            '    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As EmbarqueDetService.EmbarqueDet)
        Try
            Dim estado_process As Boolean
            estado_process = oEmbarqueDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As EmbarqueDetService.EmbarqueDet
            registro = oEmbarqueDetService.Obtener(CodEmbarque, toNumber(IdFactura))

            CodEmbarque = registro.Embarque.CodEmbarque
            IdFactura = registro.FacturaImport.IdFactura

            listaDatos()

            txtNumFactura.Text = registro.FacturaImport.NumDoc
            txtFecDoc.Value = registro.FacturaImport.FecDoc
            txtProvider.Text = registro.FacturaImport.Proveedor.DesProv
            txtCliente.Text = registro.FacturaImport.ClienteSold.DesCli
            txtTotalNeto.Value = registro.FacturaImport.TotalNeto

            txtNroPqte.Text = registro.NroPaquete
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oFacturaImportDetService.Mostrar(IdFactura).Tables(0)
            dgvDatos.DataSource = dtDatos 
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If ValidaCampos() Then
                Dim registro As New EmbarqueDetService.EmbarqueDet
                Dim Embarque As New EmbarqueDetService.Embarque
                Dim Factura As New EmbarqueDetService.FacturaImport

                Embarque.CodEmbarque = CodEmbarque
                registro.Embarque = Embarque
                Factura.IdFactura = IdFactura
                registro.FacturaImport = Factura
                registro.NroPaquete = txtNroPqte.Text
                registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    registro.FecReg = Today
                    Insertar(registro)
                End If
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtNroPqte.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class