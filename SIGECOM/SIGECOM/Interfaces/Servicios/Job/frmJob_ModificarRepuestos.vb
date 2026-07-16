Imports System.ServiceModel

Public Class frmJob_ModificarRepuestos

    Public CodJob As String
    Public CodMer As String

    Private oJobRepuestoService As New JobRepuestoService.JobRepuestoServiceClient
    Private oJobService As New JobService.JobServiceClient

    Private dtCotizacion As DataTable
    Private dtRubro As DataTable

    Private Sub frmJob_ModificarRepuestos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oJobRepuestoService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oJobRepuestoService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oJobRepuestoService.Abort()
        End Try
    End Sub

    Private Sub frmJob_ModificarRepuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= RUBRO ==============================================
            dtRubro = oJobRepuestoService.MostrarRubros.Tables(0)
            cmbRubro.DataSource = dtRubro
            cmbRubro.DropDownList.DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubro.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubro = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub frmJob_ModificarRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        ObtenerRegistro()
        If oJobService.Estado(CodJob) = 6 Or oJobService.Regularizar(CodJob) = True Then
            Activar()
        Else
            Desactivar()
        End If
    End Sub

    Private Sub Activar()
        btnModificarRepuestos.Enabled = True
        'txtCodMer.ReadOnly = False
        'txtCodMer.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        txtCantidad.ReadOnly = False
        txtCantidad.BackColor = System.Drawing.SystemColors.Window
        cbActivo.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub Desactivar()
        btnModificarRepuestos.Enabled = False
        'txtCodMer.ReadOnly = True
        'txtCodMer.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtCantidad.ReadOnly = True
        txtCantidad.BackColor = System.Drawing.SystemColors.Control
        cbActivo.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción de la Mercaderia")
                txtDescripcion.Focus()
                Return False
            ElseIf utils.toNumber(txtCantidad.Text) = 0 Then
                MsgBox("Debe Ingresar la Cantidad no puede ser Cero ")
                txtCantidad.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS CAMPOS : " + ex.Message)
        End Try
    End Function


    Private Sub Guardar()
        Try
            If ValidaCampos() Then

                Dim registro As New JobRepuestoService.JobRepuesto
                Dim job As New JobRepuestoService.Job

                job.CodJob = CodJob
                registro.Job = job
                registro.CodMer = txtCodMer.Text
                registro.DesMer = txtDescripcion.Text
                registro.CanMer = txtCantidad.Text
                'registro.CanAte = 0
                'registro.CanPen = 5
                registro.Activo = cbActivo.Checked
                registro.FecReg = Today
                registro.Observacion = utils.toNull(txtObservacion.Text)
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                Modificar(registro)

            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL DETALLE : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As JobRepuestoService.JobRepuesto)
        Try
            Dim estado_process As Boolean
            estado_process = oJobRepuestoService.Actualizar(registro)
            If estado_process Then
                MsgBox("Se Modifico Correctamente la Mercaderia")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Error en el Proceso, Comunicarse con el Administrador del Sistema")
            End If

        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnModificarRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarRepuestos.Click
        If MsgBox("¿Estás Seguro de GUARDAR el repuesto? ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Guardar()
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As JobRepuestoService.JobRepuesto
            registro = oJobRepuestoService.Obtener(CodJob, CodMer)

            txtCodMer.Text = registro.CodMer
            cmbRubro.Value = registro.RubroServicios.IdRubro
            txtDescripcion.Text = registro.DesMer
            txtCantidad.Text = registro.CanMer
            cbActivo.Checked = registro.Activo
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

End Class