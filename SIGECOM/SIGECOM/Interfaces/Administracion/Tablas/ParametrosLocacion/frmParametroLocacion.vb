Imports System.ServiceModel
Public Class frmParametroLocacion

    Private oParametrosService As New ParametrosService.ParametrosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtMonedas As DataTable
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdLocacion As String

    Private Sub frmParametroLocacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oParametrosService.Close()
        Catch ex As TimeoutException
            oParametrosService.Abort()
        Catch ex As CommunicationException
            oParametrosService.Abort()
        End Try
    End Sub

    Private Sub frmParametroLocacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmParametroLocacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        If state_button Then    'Modificar            
            LimpiarCampos()
            ObtenerRegistro()
            desactivar()
            Me.Text = "Parametro Locacion " + Chr(34) + txtIdLocacion.Text.ToString + Chr(34)
        Else 'Nuevo
            'cbActivo.Checked = True
            txtIdLocacion.Focus()
            LimpiarCampos()
            activar()
            Me.Size = New System.Drawing.Size(472, 449)
            Me.Text = "Registrar nuevo Parametro"
            txtIgv.Text = "0"
            SugerirNumero()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SugerirNumero()

    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        btnBuscarLocacion.Enabled = False
        txtIdLocacion.ReadOnly = True
        txtIdLocacion.BackColor = System.Drawing.SystemColors.Control
        cbMoneda.Enabled = False
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        txtIgv.ReadOnly = True
        txtIgv.BackColor = System.Drawing.SystemColors.Control
        txtTipoCambio.ReadOnly = True
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
        txtFactor.ReadOnly = True
        txtFactor.BackColor = System.Drawing.SystemColors.Control
        'cbActivo.Enabled = True
        txtDscto.ReadOnly = True
        txtDscto.BackColor = System.Drawing.SystemColors.Control
        txtGuiaRemision.ReadOnly = True
        txtGuiaRemision.BackColor = System.Drawing.SystemColors.Control
        txtGuiaDevolucion.ReadOnly = True
        txtGuiaDevolucion.BackColor = System.Drawing.SystemColors.Control

        txtFactContado.ReadOnly = True
        txtFactContado.BackColor = System.Drawing.SystemColors.Control
        txtFactCredito.ReadOnly = True
        txtFactCredito.BackColor = System.Drawing.SystemColors.Control
        txtBoletaContado.ReadOnly = True
        txtBoletaContado.BackColor = System.Drawing.SystemColors.Control
        txtBoletaCredito.ReadOnly = True
        txtBoletaCredito.BackColor = System.Drawing.SystemColors.Control
        txtNotaCredito.ReadOnly = True
        txtNotaCredito.BackColor = System.Drawing.SystemColors.Control
        txtNotaDebito.ReadOnly = True
        txtNotaDebito.BackColor = System.Drawing.SystemColors.Control
        txtTraInt.ReadOnly = True
        txtTraInt.BackColor = System.Drawing.SystemColors.Control
        txtTraMotor.ReadOnly = True
        txtTraMotor.BackColor = System.Drawing.SystemColors.Control
        txtComMotor.ReadOnly = True
        txtComMotor.BackColor = System.Drawing.SystemColors.Control
        txtValeReq.ReadOnly = True
        txtValeReq.BackColor = System.Drawing.SystemColors.Control
        txtLiqMotor.ReadOnly = True
        txtLiqMotor.BackColor = System.Drawing.SystemColors.Control
        txtAnticipo.ReadOnly = True
        txtAnticipo.BackColor = System.Drawing.SystemColors.Control
        txtLetra.ReadOnly = True
        txtLetra.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        btnBuscarLocacion.Enabled = IIf(state_button = False, True, False)
        txtIdLocacion.ReadOnly = True
        txtIdLocacion.BackColor = System.Drawing.SystemColors.Control
        cbMoneda.Enabled = True
        cmbCodMon.ReadOnly = False
        cmbCodMon.BackColor = System.Drawing.SystemColors.Window
        txtIgv.ReadOnly = False
        txtIgv.BackColor = System.Drawing.SystemColors.Window
        txtTipoCambio.ReadOnly = False
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Window
        txtFactor.ReadOnly = False
        txtFactor.BackColor = System.Drawing.SystemColors.Window
        'cbActivo.Enabled = True
        txtDscto.ReadOnly = False
        txtDscto.BackColor = System.Drawing.SystemColors.Window
        txtGuiaRemision.ReadOnly = False
        txtGuiaRemision.BackColor = System.Drawing.SystemColors.Window
        txtGuiaDevolucion.ReadOnly = False
        txtGuiaDevolucion.BackColor = System.Drawing.SystemColors.Window

        txtFactContado.ReadOnly = False
        txtFactContado.BackColor = System.Drawing.SystemColors.Window
        txtFactCredito.ReadOnly = False
        txtFactCredito.BackColor = System.Drawing.SystemColors.Window
        txtBoletaContado.ReadOnly = False
        txtBoletaContado.BackColor = System.Drawing.SystemColors.Window
        txtBoletaCredito.ReadOnly = False
        txtBoletaCredito.BackColor = System.Drawing.SystemColors.Window
        txtNotaCredito.ReadOnly = False
        txtNotaCredito.BackColor = System.Drawing.SystemColors.Window
        txtNotaDebito.ReadOnly = False
        txtNotaDebito.BackColor = System.Drawing.SystemColors.Window
        txtTraInt.ReadOnly = False
        txtTraInt.BackColor = System.Drawing.SystemColors.Window
        txtTraMotor.ReadOnly = False
        txtTraMotor.BackColor = System.Drawing.SystemColors.Window
        txtComMotor.ReadOnly = False
        txtComMotor.BackColor = System.Drawing.SystemColors.Window
        txtValeReq.ReadOnly = False
        txtValeReq.BackColor = System.Drawing.SystemColors.Window
        txtLiqMotor.ReadOnly = False
        txtLiqMotor.BackColor = System.Drawing.SystemColors.Window
        txtAnticipo.ReadOnly = False
        txtAnticipo.BackColor = System.Drawing.SystemColors.Window
        txtLetra.ReadOnly = False
        txtLetra.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ParametrosService.Parametro
            registro = oParametrosService.Obtener(toNumber(IdLocacion))

            txtIdLocacion.Text = registro.Locacion.IdLocacion
            cbMoneda.Checked = registro.Moneda
            cmbCodMon.Value = registro.CodMon
            txtIgv.Text = registro.Igv
            txtTipoCambio.Text = registro.TipCam
            txtFactor.Text = registro.Factor
            txtDscto.Text = registro.Dscto
            txtGuiaRemision.Text = registro.GuiRem
            txtGuiaDevolucion.Text = registro.GuiDev
            txtFactContado.Text = registro.FacCon
            txtFactCredito.Text = registro.FacCre
            txtBoletaContado.Text = registro.BolCon
            txtBoletaCredito.Text = registro.BolCre
            txtNotaCredito.Text = registro.NotaCre
            txtNotaDebito.Text = registro.NotaDeb
            txtTraInt.Text = registro.TraInt
            txtTraMotor.Text = registro.TraMot
            txtComMotor.Text = registro.ComMot
            txtValeReq.Text = registro.ValReq
            txtLiqMotor.Text = registro.LiqMotor
            txtAnticipo.Text = registro.Anticipo
            txtLetra.Text = registro.Letra

            cbAproDoc.Checked = registro.AproDoc
            cbAproOrd.Checked = registro.AprOrden
            cbConsignacion.Checked = registro.Consignacion
            cbVale.Checked = registro.UsaVale

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub LimpiarCampos()

        txtIdLocacion.Text = ""
        cbMoneda.Checked = False
        cmbCodMon.Text = ""
        txtIgv.Text = "0.00"
        txtTipoCambio.Text = "0.0000"
        'cbActivo.Enabled = True
        txtFactor.Text = "0.00"
        txtDscto.Text = "0.00"
        txtGuiaRemision.Text = "0"
        txtGuiaDevolucion.Text = "0"
        txtFactContado.Text = "0"
        txtFactCredito.Text = "0"
        txtBoletaContado.Text = "0"
        txtBoletaCredito.Text = "0"
        txtNotaCredito.Text = "0"
        txtNotaDebito.Text = "0"
        txtTraInt.Text = "0"
        txtTraMotor.Text = "0"
        txtComMotor.Text = "0"
        txtValeReq.Text = "0"
        txtLiqMotor.Text = "0"
        txtAnticipo.Text = "0"
        txtLetra.Text = "0"
        'IdLocacion = ""

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New ParametrosService.Parametro
                Dim locacion As New ParametrosService.Locacion

                'Dim proveedor As New EmpresaService.Proveedor

                locacion.IdLocacion = txtIdLocacion.Text
                registro.Locacion = locacion

                registro.Moneda = cbMoneda.Checked
                registro.CodMon = cmbCodMon.Value
                registro.Igv = txtIgv.Text
                registro.TipCam = txtTipoCambio.Text
                registro.Factor = txtFactor.Text
                registro.Dscto = txtDscto.Text
                registro.GuiRem = txtGuiaRemision.Text
                registro.GuiDev = txtGuiaDevolucion.Text
                registro.FacCon = txtFactContado.Text
                registro.FacCre = txtFactCredito.Text
                registro.BolCon = txtBoletaContado.Text
                registro.BolCre = txtBoletaCredito.Text
                registro.NotaCre = txtNotaCredito.Text
                registro.NotaDeb = txtNotaDebito.Text
                registro.TraInt = txtTraInt.Text
                registro.TraMot = txtTraMotor.Text
                registro.ComMot = txtComMotor.Text
                registro.ValReq = txtValeReq.Text
                registro.LiqMotor = txtLiqMotor.Text
                registro.Anticipo = txtAnticipo.Text
                registro.Letra = txtLetra.Text

                registro.AproDoc = cbAproDoc.Checked
                registro.AprOrden = cbAproOrd.Checked
                registro.Consignacion = cbConsignacion.Checked
                registro.UsaVale = cbVale.Checked

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtIdLocacion.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo Locacion", MsgBoxStyle.Information, "Información")
                txtIdLocacion.BackColor = Color.Red
                txtIdLocacion.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub Insertar(ByVal registro As ParametrosService.Parametro)
        Try
            Dim estado_process As Boolean
            estado_process = oParametrosService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó el parametro correctamente")
                IdLocacion = txtIdLocacion.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL PARAMETRO LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ParametrosService.Parametro)
        Try
            Dim estado_process As Boolean
            estado_process = oParametrosService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL PARAMETRO LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarLocacion_Click(sender As Object, e As EventArgs) Handles btnBuscarLocacion.Click
        Dim frm As New frmBuscadorLocacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdLocacion = frm.codigo
            txtIdLocacion.Text = frm.codigo
        End If
    End Sub
End Class