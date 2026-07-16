Imports System.ServiceModel
Public Class frmGastoRealConsulta_Nuevo

    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oJobService As New JobService.JobServiceClient

    Public IdPersona As Integer
    Public IdGastoReal As Integer
    Public Actualizar As Boolean
    Dim dtSubRubros As DataTable
    Dim dtRubros As DataTable
    Dim dtPlaca As DataTable
    Dim dtMoneda As DataTable
    Dim dtTipDoc As DataTable

    Private Sub frmGastoRealConsulta_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastoRealService.Close()
            oJobService.Close()
            oMaestroService.Close()
            oVehiculoService.Close()
        Catch ex As TimeoutException
            oGastoRealService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
        Catch ex As CommunicationException
            oGastoRealService.Abort()
            oJobService.Abort()
            oMaestroService.Abort()
            oVehiculoService.Abort()
        End Try
    End Sub


    Private Sub frmGastoRealConsulta_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub frmGastoRealConsulta_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarCombos()
        If Actualizar = True Then
            ObtenerRegistro()
            Desactivar()
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Protected Sub Desactivar()
        txtCodJob.ReadOnly = True
        cmbRubro.ReadOnly = True
        cmbSubRubro.ReadOnly = True
        txtUsuario.ReadOnly = True
        txtProveedor.ReadOnly = True
        cmbTipDoc.ReadOnly = True
        txtNumDoc.ReadOnly = True
        txtRuc.ReadOnly = True
        txtFecha.ReadOnly = True
        txtDescripcion.ReadOnly = True
        cmbMoneda.ReadOnly = True
        txtTotal.ReadOnly = True
        cmbPlaca.ReadOnly = True
    End Sub

    Protected Sub ObtenerRegistro()
        Try
            Dim registro As GastoRealService.GastoReal
            registro = oGastoRealService.Obtener(IdGastoReal)

            txtCodJob.Text = registro.Job.CodJob
            IdPersona = registro.Persona.IdPer
            txtUsuario.Text = registro.Persona.ApeNom
            txtProveedor.Text = registro.Proveedor
            cmbRubro.Value = registro.RubroGasto.CodRubro
            listaSubRubro()
            cmbSubRubro.Value = registro.SubRubroGasto.CodSubRubro
            cmbTipDoc.Value = registro.TipoDocumento.IdDocumento
            txtNumDoc.Text = registro.NumDoc
            txtRuc.Text = registro.Ruc
            txtFecha.Text = registro.Fecha
            txtDescripcion.Text = registro.Descripcion
            cmbMoneda.Value = registro.Moneda.CodMon
            If cmbMoneda.Value = "US" Then
                txtTotal.Value = utils.toDouble(registro.MontoDol)
            Else
                txtTotal.Value = utils.toDouble(registro.MontoSol)
            End If
            cmbPlaca.Value = registro.Unidad.Placa

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO : " + ex.Message)
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
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception

        End Try
        Try
            fila(7) = 0
        Catch ex As Exception

        End Try
        Try
            fila(8) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Protected Sub listaSubRubro()
        Try
            '-------------------------------Sub Rubros-----------------------------
            dtSubRubros = oGastoRealService.MostrarSubRubros(cmbRubro.Value).Tables(0)
            dtSubRubros.Rows.InsertAt(getRowTodos(dtSubRubros), 0)
            cmbSubRubro.DataSource = dtSubRubros
            cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.SelectedIndex = 0
            dtSubRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR COMBO SUBRUBRO : " + ex.Message)
        End Try
    End Sub

    Protected Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '-------------------------------Moneda-----------------------------
            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            dtMoneda.Rows.InsertAt(getRowTodos(dtMoneda), 0)
            cmbMoneda.DataSource = dtMoneda
            cmbMoneda.DropDownList.DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.SelectedIndex = 0
            dtMoneda = Nothing

            '-------------------------------Placa-----------------------------
            dtPlaca = oVehiculoService.MostrarUnidades.Tables(0)
            dtPlaca.Rows.InsertAt(getRowTodos1(dtPlaca), 0)
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

End Class