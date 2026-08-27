Imports System.ServiceModel
Public Class frmGastoViaje_ModificarDet

    Private oPreGastoRealDetService As New PreGastoRealDetService.PreGastoRealDetServiceClient
    Private oPreGastoRealService As New PreGastoRealService.PreGastoRealServiceClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient

    Private dtRubro As DataTable
    Private dtSubRubros As DataTable
    Private dtTipDoc As DataTable
    Private dtPlaca As DataTable
    Private IdProveedor As Integer
    Public IdPreGastoRealDet As Integer

    Private Sub frmGastoViaje_ModificarDet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPreGastoRealDetService.Close()
            oPreGastoRealService.Close()
            oGastoRealService.Close()
            oVehiculoService.Close()
        Catch ex As TimeoutException
            oPreGastoRealDetService.Abort()
            oPreGastoRealService.Abort()
            oGastoRealService.Abort()
            oVehiculoService.Abort()
        Catch ex As CommunicationException
            oPreGastoRealDetService.Abort()
            oPreGastoRealService.Abort()
            oGastoRealService.Abort()
            oVehiculoService.Abort()
        End Try
    End Sub

    Private Sub frmGastoViaje_ModificarDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoViaje_ModificarDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        ObtenerRegistro()
        Dim IdPreGastoReal As PreGastoRealDetService.PreGastoRealDet
        IdPreGastoReal = oPreGastoRealDetService.Obtener(IdPreGastoRealDet)
        If Session.CodPerfil = "17" Then
            btnGuardarDet.Enabled = IIf(oPreGastoRealService.Estado(IdPreGastoReal.PreGastoReal.IdPreGastoReal) = 0 Or oPreGastoRealService.Estado(IdPreGastoReal.PreGastoReal.IdPreGastoReal) = 1, True, False)
        Else
            btnGuardarDet.Enabled = IIf(oPreGastoRealService.Estado(IdPreGastoReal.PreGastoReal.IdPreGastoReal) = 0 Or (Session.CodPerfil = "24" And oPreGastoRealService.Estado(IdPreGastoReal.PreGastoReal.IdPreGastoReal) <> 3), True, False)
        End If
    End Sub

    Private Function ValidaCamposDet() As Boolean
        Try
            If txtFechaDet.Value = Nothing Then
                MsgBox("Debe ingresar la fecha del detalle del gasto de viaje")
                txtFechaDet.Focus()
                Return False
            ElseIf cmbRubro.Text = "" Then
                MsgBox("Debe ingresar el codigo del rubro")
                cmbRubro.Focus()
                Return False
            ElseIf cmbTipDoc.Text = "" Then
                MsgBox("Debe ingresar el tipo documento")
                cmbTipDoc.Focus()
                Return False
            ElseIf txtDescripcion.Text = "" Then
                MsgBox("Debe ingresar la descripción")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS DEL DETALLE " + ex.Message)
        End Try
    End Function

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception

        End Try
        Try
            fila(2) = ""
        Catch ex As Exception

        End Try
        Try
            fila(3) = ""
        Catch ex As Exception

        End Try
        Try
            fila(4) = ""
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Protected Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubro = oPreGastoRealDetService.MostrarRubros.Tables(0)
            dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            'cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

            '-------------------------------Placa-----------------------------
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos(dtPlaca), 0)
            cmbPlaca.DataSource = dtPlaca
            cmbPlaca.DropDownList.DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.DisplayMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.ValueMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(0).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.DropDownList.Columns(1).DataMember = dtPlaca.Columns("Placa").ToString
            cmbPlaca.SelectedIndex = 0
            dtPlaca = Nothing

            '-------------------------------Tipo Documento -----------------------------
            dtTipDoc = oGastoRealService.MostrarTipoDocumento.Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipDoc.DataSource = dtTipDoc
            cmbTipDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipDoc.SelectedIndex = 0
            dtTipDoc = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR LOS COMBOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub ObtenerRegistro()
        Try
            Dim registro As PreGastoRealDetService.PreGastoRealDet
            registro = oPreGastoRealDetService.Obtener(IdPreGastoRealDet)


            txtFechaDet.Value = registro.Fecha
            cmbTipDoc.Value = utils.toNumber(registro.TipoDocumento.IdDocumento)
            txtSerieDoc.Text = registro.SerDoc
            txtNumDoc.Text = registro.NumDoc
            txtRuc.Text = registro.Proveedor.RucProv
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtDescripcion.Text = registro.Descripcion
            txtTotal.Value = registro.Monto
            cmbPlaca.Value = registro.Placa
            cmbRubro.Value = registro.RubroGastoViaje.CodRubro
            llenarSubRubros()
            cmbSubRubro.Value = registro.SubRubroGastoViaje.CodSubRubro

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS :  " + ex.Message)
        End Try
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        Try
            llenarSubRubros()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR SUB RUBROS : " + ex.Message)
        End Try
    End Sub

    Protected Sub llenarSubRubros()

        '-------------------------------Concepto -----------------------------
        dtSubRubros = oPreGastoRealDetService.MostrarSubRubros(cmbRubro.Value).Tables(0)
        dtSubRubros.Rows.InsertAt(getRowTodos(dtSubRubros), 0)
        cmbSubRubro.DataSource = dtSubRubros
        cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
        cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
        cmbSubRubro.SelectedIndex = 0
        dtSubRubros = Nothing

    End Sub

    Protected Sub ModificarDetalle(ByVal registro As PreGastoRealDetService.PreGastoRealDet)
        Try

            Try
                Dim estado_process As Integer
                estado_process = oPreGastoRealDetService.Actualizar(registro)
                If estado_process Then
                    MsgBox("Se modificarón los datos correctamente")
                    Me.Close()
                Else
                    MsgBox("Error en el proceso , comunicarse con el administrador del TI ")
                End If
            Catch ex As Exception
                MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
            End Try

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL DETALLE : " + ex.Message)
        End Try
    End Sub

    Protected Sub GuardarDetalle()

        If ValidaCamposDet() Then

            Dim registro As New PreGastoRealDetService.PreGastoRealDet
            Dim pregastoreal As New PreGastoRealDetService.PreGastoReal
            Dim rubrogastoviaje As New PreGastoRealDetService.RubroGastoViaje
            Dim subrubrogastoviaje As New PreGastoRealDetService.SubRubroGastoViaje
            Dim tipodocumento As New PreGastoRealDetService.TipoDocumento
            Dim IdPreGastoReal As PreGastoRealDetService.PreGastoRealDet
            Dim proveedor As New PreGastoRealDetService.Proveedor
            IdPreGastoReal = oPreGastoRealDetService.Obtener(IdPreGastoRealDet)

            pregastoreal.IdPreGastoReal = IdPreGastoReal.PreGastoReal.IdPreGastoReal
            registro.PreGastoReal = pregastoreal
            registro.IdPreGastoRealDet = IdPreGastoRealDet
            registro.Fecha = txtFechaDet.Value
            rubrogastoviaje.CodRubro = cmbRubro.Value
            registro.RubroGastoViaje = rubrogastoviaje
            subrubrogastoviaje.CodSubRubro = utils.toNull(cmbSubRubro.Value)
            registro.SubRubroGastoViaje = subrubrogastoviaje
            tipodocumento.IdDocumento = cmbTipDoc.Value
            registro.TipoDocumento = tipodocumento
            registro.SerDoc = txtSerieDoc.Text
            registro.NumDoc = txtNumDoc.Text
            'registro.ruc = txtRuc.Text
            proveedor.IdProveedor = utils.toNull(IdProveedor)
            proveedor.RucProv = utils.toNull(txtRuc.Text)
            registro.Proveedor = proveedor

            registro.Descripcion = txtDescripcion.Text
            registro.Monto = txtTotal.Value
            registro.Placa = utils.toNull(cmbPlaca.Value)
            registro.FecRegistro = Today
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            ModificarDetalle(registro)

        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarDet.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            GuardarDetalle()
        End If
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtRuc.Text = frm.ruc
                    txtDescripcion.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
                txtRuc.Text = frm.RucProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class