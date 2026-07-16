Imports System.ServiceModel
Public Class frmArqueoCaja_Det

    '============================Servicios===================================
    Private oArqueoCajaService As New ArqueoCajaService.ArqueoCajaServiceClient
    Private oArqueoCajaDetService As New ArqueoCajaDetService.ArqueoCajaDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdArqueoDet As Integer
    Public IdArqueo As Integer
    Public estado As String    
    Private dtMonedas As DataTable
    Private dtConcepto As DataTable
    Private dtDatos As DataTable

    Private Sub frmArqueoCaja_Det_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmArqueoCaja_Det_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        estado = oArqueoCajaService.ObtenerEstado(toNumber(IdArqueo))
        llenarCombos()
        cmbConcepto.Focus()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            cmbConcepto.Focus()
        Else                          'Nuevo
            activar()
            cmbConcepto.Focus()
            cmbMoneda.Value = "NS"
        End If
        EnableOptions()
        cmbConcepto.Focus()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      cmbConcepto.KeyPress _
                    , cmbMoneda.KeyPress _
                    , txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmArqueoCaja_Det_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oArqueoCajaService.Close()
            oArqueoCajaDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oArqueoCajaService.Abort()
            oArqueoCajaDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oArqueoCajaService.Abort()
            oArqueoCajaDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
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
            fila(3) = "(Ninguno)"
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
            fila(4) = "(Ninguno)"
        End Try
        Return fila
    End Function

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbConcepto.Value) = "" Then
                MsgBox("Debe Ingresar el Concepto. ", MsgBoxStyle.Information, "Información")
                cmbConcepto.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf oReembolsoCajaDetService.BuscarTipoVehiculo(cmbTipoGasto.Value) And cmbPlaca.SelectedIndex = 0 Then
                '    MsgBox("Debe Ingresar la Placa", MsgBoxStyle.Information, "Información")
                '    cmbPlaca.Focus()
                '    Return False            
            ElseIf toDouble(txtMonto.Value) < 0 Then
                MsgBox("El monto no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()
        If estado = "GN" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()
        cmbConcepto.ReadOnly = False
        cmbConcepto.BackColor = System.Drawing.SystemColors.Window
        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window        
        txtMonto.ReadOnly = False
        txtMonto.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window        
    End Sub

    Private Sub desactivar()
        estado = oArqueoCajaService.ObtenerEstado(IdArqueo)
        If estado = "GN" Then
            activar()
        Else
            cmbConcepto.ReadOnly = True
            cmbConcepto.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtDescripcion.ReadOnly = True
            txtDescripcion.BackColor = System.Drawing.SystemColors.Control            
        End If
    End Sub

    Private Sub Insertar(ByVal registro As ArqueoCajaDetService.ArqueoCajaDet)
        Try
            Dim estado_process As Integer            
            estado_process = oArqueoCajaDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdArqueoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ArqueoCajaDetService.ArqueoCajaDet)
        Try
            Dim estado_process As Boolean
            estado_process = oArqueoCajaDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ArqueoCajaDetService.ArqueoCajaDet
            registro = oArqueoCajaDetService.Obtener(IdArqueoDet)

            IdArqueo = registro.ArqueoCaja.IdArqueo
            IdArqueoDet = registro.IdArqueoDet
            cmbConcepto.Value = registro.ConceptoArqueo.IdConcepto
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMonto.Value = registro.Monto
            txtDescripcion.Text = registro.Descripcion            
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '=======================================MONEDAS ===============================================
            dtConcepto = oArqueoCajaDetService.MostrarConceptoArqueo().Tables(0)
            cmbConcepto.DataSource = dtConcepto
            cmbConcepto.DropDownList.DataMember = dtConcepto.Columns("DesConcepto").ToString
            cmbConcepto.DropDownList.DisplayMember = dtConcepto.Columns("DesConcepto").ToString
            cmbConcepto.DropDownList.ValueMember = dtConcepto.Columns("IdConcepto").ToString
            cmbConcepto.DropDownList.Columns(0).DataMember = dtConcepto.Columns("IdConcepto").ToString
            cmbConcepto.DropDownList.Columns(1).DataMember = dtConcepto.Columns("DesConcepto").ToString
            cmbConcepto.SelectedIndex = 0
            dtConcepto = Nothing

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
                Dim registro As New ArqueoCajaDetService.ArqueoCajaDet
                Dim Arqueo As New ArqueoCajaDetService.ArqueoCaja
                Dim Concepto As New ArqueoCajaDetService.ConceptoArqueo
                Dim Moneda As New ArqueoCajaDetService.Moneda

                registro.IdArqueoDet = IdArqueoDet
                Arqueo.IdArqueo = IdArqueo
                registro.ArqueoCaja = Arqueo
                Concepto.IdConcepto = cmbConcepto.Value
                registro.ConceptoArqueo = Concepto
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Monto = txtMonto.Value
                registro.Descripcion = txtDescripcion.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class