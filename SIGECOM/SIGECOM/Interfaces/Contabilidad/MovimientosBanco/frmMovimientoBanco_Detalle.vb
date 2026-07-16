Imports System.ServiceModel

Public Class frmMovimientoBanco_Detalle

    Private oMovimientoBancosService As New MovimientoBancosService.MovimientoBancosServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public Mes As Integer
    Public Anio As Integer
    Private dtTipoMov As DataTable
    Public IdMovimiento As Integer
    Public IdMovimientoDet As Integer

    Private Sub frmMovimientoBanco_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMovimientoBancosService.Close()
        Catch ex As TimeoutException
            oMovimientoBancosService.Abort()
        Catch ex As CommunicationException
            oMovimientoBancosService.Abort()
        End Try
    End Sub

    Private Sub frmMovimientoBanco_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimientoBanco_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()

        If state_button Then    'Modificar 
            ObtenerRegistro()
        Else                          'Nuevo
            Me.Text = "Nuevo Detalle"

            txtFecPlanilla.Text = CDate("01/" & Trim(Mes) & "/" & Trim(Anio))
            txtFecBanco.Text = CDate("01/" & Trim(Mes) & "/" & Trim(Anio))

        End If

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As MovimientoBancosService.MovimientoBancosDet
            registro = oMovimientoBancosService.ObtenerDetalle(IdMovimientoDet)

            IdMovimientoDet = registro.IdMovimientoDet
            'txtIdMovimiento.Text = registro.IdMovimiento
            txtFecPlanilla.Value = registro.FecPlanilla
            txtFecBanco.Value = registro.FecBanco
            txtCheque.Text = registro.Cheque
            txtDescripcion.Text = registro.Descripcion
            cmbTipMov.Value = registro.TipoMovBanco.CodTipo
            cbConciliar.Checked = registro.Conciliar
            txtMonto.Value = registro.Monto


            Me.Text = "Movimiento Banco Detalle Nº " + registro.IdMovimientoDet.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub


    Private Sub llenarCombos()

        Try
            '======================================= MESES ================================================
            dtTipoMov = oMovimientoBancosService.MostrarTipoMovBanco().Tables(0)
            'dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbTipMov.DataSource = dtTipoMov
            cmbTipMov.DropDownList.DataMember = dtTipoMov.Columns("Descripcion").ToString
            cmbTipMov.DropDownList.DisplayMember = dtTipoMov.Columns("Descripcion").ToString
            cmbTipMov.DropDownList.ValueMember = dtTipoMov.Columns("CodTipo").ToString
            cmbTipMov.DropDownList.Columns(0).DataMember = dtTipoMov.Columns("CodTipo").ToString
            cmbTipMov.DropDownList.Columns(1).DataMember = dtTipoMov.Columns("Descripcion").ToString
            cmbTipMov.DropDownList.Columns(2).DataMember = dtTipoMov.Columns("TipMov").ToString
            cmbTipMov.SelectedIndex = 0
            dtTipoMov = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecPlanilla.Text) = "" Then
                MsgBox("Debe Ingresar la fecha de la planilla", MsgBoxStyle.Information, "Información")
                txtFecPlanilla.BackColor = Color.Red
                txtFecPlanilla.Focus()
                Return False
            ElseIf toBlank(txtFecBanco.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del banco", MsgBoxStyle.Information, "Información")
                txtFecPlanilla.BackColor = Color.Red
                txtFecPlanilla.Focus()
                Return False

                'ElseIf toBlank(txtCheque.Text) = "" Then
                '    MsgBox("Debe Ingresar el cheque", MsgBoxStyle.Information, "Información")
                '    txtFecPlanilla.BackColor = Color.Red
                '    txtFecPlanilla.Focus()
                '    Return False
                'ElseIf toDouble(txtMonto.Value) <= 0 Then
                '    MsgBox("El Monto debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                '    txtMonto.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New MovimientoBancosService.MovimientoBancosDet
                Dim MovimientoBancos As New MovimientoBancosService.MovimientoBancos
                Dim TipoMovBanco As New MovimientoBancosService.TipoMovBanco

                MovimientoBancos.IdMovimiento = IdMovimiento
                registro.MovimientoBancos = MovimientoBancos
                registro.IdMovimientoDet = IdMovimientoDet
                registro.FecBanco = txtFecBanco.Value
                registro.FecPlanilla = txtFecPlanilla.Value

                registro.Cheque = txtCheque.Text
                registro.Descripcion = txtDescripcion.Text
                TipoMovBanco.CodTipo = toBlank(cmbTipMov.Value)
                TipoMovBanco.TipMov = cmbTipMov.DropDownList.GetRow.Cells(2).Text
                registro.TipoMovBanco = TipoMovBanco

                registro.Conciliar = cbConciliar.Checked
                registro.Monto = toDouble(txtMonto.Value)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL MOVIMIENTO BANCO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub Insertar(ByVal registro As MovimientoBancosService.MovimientoBancosDet)
        Try
            Dim estado_process As Integer
            estado_process = oMovimientoBancosService.InsertarDetalle(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdMovimientoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MovimientoBancosService.MovimientoBancosDet)
        Try
            Dim estado_process As Boolean
            estado_process = oMovimientoBancosService.ActualizarDetalle(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'desactivar()
                'ObtenerRegistro()
                'ActualizarDetallesCentroCosto()
                'ActualizarDetallesJob()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtMonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            biGuardar.Select()
            biGuardar_Click(sender, e)
        End If
    End Sub


    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtFecPlanilla.KeyPress, txtFecBanco.KeyPress, txtCheque.KeyPress, txtDescripcion.KeyPress, _
                        cmbTipMov.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


End Class