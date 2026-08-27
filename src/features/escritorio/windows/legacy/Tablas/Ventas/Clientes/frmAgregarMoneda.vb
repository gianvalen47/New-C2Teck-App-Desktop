Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmAgregarMoneda
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtAlmacenesAsignado As DataTable
    Dim fila As DataRow
    'Dim dtopcion As DataTable
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oClienteService As New ClienteService.ClienteServiceClient

    Dim dato As String
    Dim numero As String
    Public CodUsu As String
    Public IdCliente As Integer
    Public type_process As Boolean

    Private Sub frmAgregarMoneda_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oClienteService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oClienteService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oClienteService.Abort()
        End Try
    End Sub

    Private Sub frmAgregarMoneda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAgregarMoneda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        dtAlmacenesAsignado = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmdOficina.Value, "").Tables(0)
        dtAlmacenesAsignado.Clear()
    End Sub

    Private Sub llenarCombos()
        Try
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmdOficina.DataSource = dtOficinas
            cmdOficina.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmdOficina.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmdOficina.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.SelectedIndex = 0
            dtOficinas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmdOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOficina.ValueChanged
        dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmdOficina.Value, "").Tables(0)
        dgvOpcion.DataSource = dtAlmacenes
        codigo.DataPropertyName = dtAlmacenes.Columns("IdLocacion").ColumnName
        descripcion.DataPropertyName = dtAlmacenes.Columns("DesAlm").ColumnName
        ocultarColumnas()
        descripcion.Width = 150
        codigo.Width = 50
    End Sub

    Private Sub OcultarColumnas()
        dgvOpcion.Columns("IdLocacion").Visible = False
        dgvOpcion.Columns("CodEmp").Visible = False
        dgvOpcion.Columns("CodOfi").Visible = False
        dgvOpcion.Columns("DesOfi").Visible = False
        dgvOpcion.Columns("CodAlm").Visible = False
        dgvOpcion.Columns("DesAlm").Visible = False
        dgvOpcion.Columns("AbrAlm").Visible = False
        dgvOpcion.Columns("GruVen").Visible = False
        dgvOpcion.Columns("GruAlm").Visible = False
        dgvOpcion.Columns("AproDoc").Visible = False
    End Sub

    Private Sub ocultarColumnasAsignado()
        dgvOpcionAsignada.Columns("CodEmp").Visible = False
        dgvOpcionAsignada.Columns("CodOfi").Visible = False
        dgvOpcionAsignada.Columns("DesOfi").Visible = False
        dgvOpcionAsignada.Columns("AbrAlm").Visible = False
        dgvOpcionAsignada.Columns("CodAlm").Visible = False
        dgvOpcionAsignada.Columns("GruVen").Visible = False
        dgvOpcionAsignada.Columns("GruAlm").Visible = False
        dgvOpcionAsignada.Columns("AproDoc").Visible = False
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim dr As DataRow
        dr = dtAlmacenesAsignado.NewRow
        dgvOpcionAsignada.DataSource = dtAlmacenesAsignado
        numero = dgvOpcion.Rows(dgvOpcion.CurrentRow.Index).Cells("IdLocacion").Value.ToString
        dato = dgvOpcion.Rows(dgvOpcion.CurrentRow.Index).Cells("DesAlm").Value.ToString
        dr("IdLocacion") = numero
        dr("DesAlm") = dato
        dtAlmacenesAsignado.Rows.Add(dr)
        ocultarColumnasAsignado()
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        dgvOpcionAsignada.Rows.Remove(dgvOpcionAsignada.CurrentRow)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR las locaciones?: ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_busqueda As Boolean
                Dim estado_process As Boolean
                For Each fila As DataRow In dtAlmacenesAsignado.Rows
                    estado_busqueda = oClienteService.BuscarMonedaCliente(fila.Item("IdLocacion"), IdCliente)
                    If estado_busqueda = True Then
                        MsgBox("Una o Algunas de las locaciones seleccionadas ya estan Activadas", MsgBoxStyle.Information)
                    Else
                        estado_process = oClienteService.InsertarMonedaCliente(fila.Item("IdLocacion"), IdCliente, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If
                Next

                If estado_process Then
                    MsgBox("Se agregó las locaciones correctamente")
                    dtAlmacenesAsignado.Clear()
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    'Me.Close()
                Else
                    'MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class