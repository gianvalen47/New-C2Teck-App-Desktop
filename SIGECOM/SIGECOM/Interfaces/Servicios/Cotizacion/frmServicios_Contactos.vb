Public Class frmServicios_Contactos

    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Public Contacto As String
    Public Cliente As Integer
    Public IdCotizacionSer As Integer
    Private dtMenuOpcion As DataTable
    Private dtMenuOpcionAsignado As DataTable

    Dim IdContacto As Integer
    'Dim IdCliente As Integer
    'Dim IdTipoContacto As Integer
    'Dim NomTipo As String
    'Dim Titulo As String
    'Dim Nombres As String
    'Dim Apellidos As String
    Dim ApeNom As String
    ' Dim FecNac As Date
    'Dim Sexo As String
    'Dim Direccion As String
    'Dim Email As String
    'Dim EmailProm As String
    'Dim Telefonos As String
    'Dim TelMovil As String
    'Dim Fax As String
    'Dim ModifiedDate As Date

    Public dtContacto As New DataTable
    Public Concatenado As String
    Public state As Boolean = False
    Public state_button As Boolean

    Private Sub frmServicios_Contactos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oContactoService) = False Then
                oContactoService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Contactos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub frmServicios_Contactos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim estilo As New Estilo
        'estilo.cargaEstiloDataDrid(dgvOpcionMenu)
        dgvOpcionMenu.AutoGenerateColumns = False
        dgvOpcionMenuAsignado.AutoGenerateColumns = False
        listaDatos()
       
        ' ocultarColumnasAsignado()
    End Sub
    Private Sub listaDatos()
        Try
            'If state_button Then

            dtMenuOpcion = oContactoService.Mostrar(Cliente).Tables(0)
            dgvOpcionMenu.DataSource = dtMenuOpcion

            cIdContacto.DataPropertyName = dtMenuOpcion.Columns("IdContacto").ColumnName
            cApeNom.DataPropertyName = dtMenuOpcion.Columns("ApeNom").ColumnName
            '-----------------------------------------------------------------------------------------------------
            dtMenuOpcionAsignado = oCotizacionServicioService.MostrarContactos(IdCotizacionSer).Tables(0)
            dgvOpcionMenuAsignado.DataSource = dtMenuOpcionAsignado

            cIdContacto1.DataPropertyName = dtMenuOpcionAsignado.Columns("IdContacto").ColumnName
            cApeNom1.DataPropertyName = dtMenuOpcionAsignado.Columns("ApeNom").ColumnName

            'ocultarColumnas()
            Dim ElementosEliminar As ArrayList = New ArrayList

            For y As Integer = 0 To dgvOpcionMenuAsignado.RowCount - 1
                For x As Integer = 0 To dgvOpcionMenu.RowCount - 1

                    Dim a As Integer = dgvOpcionMenu.Item("cIdContacto", x).Value
                    Dim b As Integer = dgvOpcionMenuAsignado.Item("cIdContacto1", y).Value
                    If a = b Then
                        ElementosEliminar.Add(dgvOpcionMenu.Rows.Item(x))
                    End If
                Next
            Next
            For i As Integer = 0 To ElementosEliminar.Count - 1
                dgvOpcionMenu.Rows.Remove(ElementosEliminar.Item(i))

            Next
            'For Each row As DataRow In dtMenuOpcion.Rows
            '    For Each rowAsignado In dtMenuOpcionAsignado.Rows
            '        If row.Item(0) = rowAsignado.Item(1) Then
            '            EliminarFila(dgvOpcionMenu)
            '        End If
            '    Next

            'Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        AgregarFila(dtMenuOpcionAsignado, dgvOpcionMenuAsignado, dgvOpcionMenu)

    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtMenuOpcion, dgvOpcionMenu, dgvOpcionMenuAsignado)
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView )
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)

    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()
            dgvDatosAsignado.DataSource = dtDatos
            IdContacto = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdContacto").Value.ToString
            'IdCliente = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("IdCliente").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom").Value.ToString

            dr("IdContacto") = IdContacto
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()
            dgvDatosAsignado.DataSource = dtDatos

            IdContacto = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdContacto1").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom1").Value.ToString

            dr("IdContacto") = IdContacto
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            EliminarFila(dgvDatos)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    'Private Sub ocultarColumnasAsignado()
    '    'dgvOpcionMenuAsignado.Columns("IdContacto").Visible = False
    '    dgvOpcionMenuAsignado.Columns("IdCliente").Visible = False
    '    dgvOpcionMenuAsignado.Columns("IdTipoContacto").Visible = False
    '    dgvOpcionMenuAsignado.Columns("NomTipo").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Titulo").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Nombres").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Apellidos").Visible = False
    '    'dgvOpcionMenuAsignado.Columns("ApeNom").Visible = False
    '    dgvOpcionMenuAsignado.Columns("FecNac").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Sexo").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Direccion").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Email").Visible = False
    '    dgvOpcionMenuAsignado.Columns("EmailProm").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Telefonos").Visible = False
    '    dgvOpcionMenuAsignado.Columns("TelMovil").Visible = False
    '    dgvOpcionMenuAsignado.Columns("Fax").Visible = False
    '    dgvOpcionMenuAsignado.Columns("ModifiedDate").Visible = False
    'End Sub


    'Private Sub ocultarColumnas()
    '    dgvOpcionMenu.Columns("IdContacto").Visible = True
    '    dgvOpcionMenu.Columns("IdCliente").Visible = False
    '    dgvOpcionMenu.Columns("IdTipoContacto").Visible = False
    '    dgvOpcionMenu.Columns("NomTipo").Visible = False
    '    dgvOpcionMenu.Columns("Titulo").Visible = False
    '    dgvOpcionMenu.Columns("Nombres").Visible = False
    '    dgvOpcionMenu.Columns("Apellidos").Visible = False
    '    dgvOpcionMenu.Columns("ApeNom").Visible = True
    '    dgvOpcionMenu.Columns("FecNac").Visible = False
    '    dgvOpcionMenu.Columns("Sexo").Visible = False
    '    dgvOpcionMenu.Columns("Direccion").Visible = False
    '    dgvOpcionMenu.Columns("Email").Visible = False
    '    dgvOpcionMenu.Columns("EmailProm").Visible = False
    '    dgvOpcionMenu.Columns("Telefonos").Visible = False
    '    dgvOpcionMenu.Columns("TelMovil").Visible = False
    '    dgvOpcionMenu.Columns("Fax").Visible = False
    '    dgvOpcionMenu.Columns("ModifiedDate").Visible = False
    'End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Concatenado = ""
        'dtContacto.Columns.Add(New DataColumn("IdContacto", Type.GetType("System.String")))
        'dtContacto.Columns.Add(New DataColumn("ApeNom", Type.GetType("System.String")))
        
        dtContacto = dgvOpcionMenuAsignado.DataSource
        dtContacto.AcceptChanges()
        For Each row As DataGridViewRow In dgvOpcionMenuAsignado.Rows

            If Concatenado = "" Then
                Concatenado = Concatenado + row.Cells("cApeNom1").Value

            Else
                 Concatenado = Concatenado + "/" + row.Cells("cApeNom1").Value
            End If
        Next
        'For i As Integer = 0 To dtContacto.Rows.Count - 1
        '    If Concatenado = "" Then
        '        Concatenado = Concatenado + dtContacto.Rows(i).Item(1).ToString
        '    Else
        '        Concatenado = Concatenado + "/" + dtContacto.Rows(i).Item(1).ToString
        '    End If
        'Next

        If dtContacto.Rows.Count > 0 Then
            state = True
        Else
            state = False
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        If Cliente > 0 Then
            Dim forma As New frmAgregarContacto
            forma.IdCliente = Cliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                'cmbIdContacto.Value = toNumber(forma.txtIdContacto.Text)
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdContacto.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        ' cmbIdContacto.Select()
    End Sub
End Class