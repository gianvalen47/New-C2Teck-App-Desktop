
Imports System.Windows.Forms


Public Class frmBuscarUbigeo
    Private ObjCliente As New ClienteService.ClienteServiceClient
    Private dtUbigeo As New DataTable
    Public state_button As Boolean
    Public CodUbigeo As String
    Public Nombre As String

    Public Departamento As String
    Public Provincia As String
    Public Distrito As String

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cmbdepartamentos.KeyPress _
            , cmbprovincias.KeyPress _
            , cmbdistritos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmBuscarUbigeo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            cmbdepartamentos.ReadOnly = False
            cmbdistritos.ReadOnly = False
            cmbprovincias.ReadOnly = False
            ObtenerRegistro()
        Else                    'Nuevo
            cmbdepartamentos.ReadOnly = False
            cmbdistritos.ReadOnly = False
            cmbprovincias.ReadOnly = False
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If isClosed(ObjCliente) = False Then
            ObjCliente.Close()
        End If
        If isClosed(ObjCliente) = False Then
            ObjCliente.Close()
        End If
    End Sub

   
    Private Sub llenarCombos()
        Try
            '======================================= DEPARTAMENTOS =======================================

            dtUbigeo = ObjCliente.MostrarDepartamentos.Tables(0)
            cmbdepartamentos.DataSource = dtUbigeo
            cmbdepartamentos.DropDownList.DataMember = dtUbigeo.Columns("NomDpto").ToString
            cmbdepartamentos.DropDownList.DisplayMember = dtUbigeo.Columns("NomDpto").ToString
            cmbdepartamentos.DropDownList.ValueMember = dtUbigeo.Columns("CodDpto").ToString
            cmbdepartamentos.DropDownList.Columns(0).DataMember = dtUbigeo.Columns("CodDpto").ToString
            cmbdepartamentos.DropDownList.Columns(1).DataMember = dtUbigeo.Columns("NomDpto").ToString

            cmbdepartamentos.Value = "15"

            cmbdistritos.Refresh()
            dtUbigeo = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()

    End Sub
   
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbdepartamentos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepartamentos.ValueChanged

        Try

            '======================================= PROVINCIAS =========================================
            cmbprovincias.Refresh()

            dtUbigeo = ObjCliente.MostrarProvincias(cmbdepartamentos.Value).Tables(0)
            cmbprovincias.DataSource = dtUbigeo
            cmbprovincias.DropDownList.DataMember = dtUbigeo.Columns("NomProv").ToString
            cmbprovincias.DropDownList.DisplayMember = dtUbigeo.Columns("NomProv").ToString
            cmbprovincias.DropDownList.ValueMember = dtUbigeo.Columns("CodProv").ToString
            cmbprovincias.DropDownList.Columns(0).DataMember = dtUbigeo.Columns("CodProv").ToString
            cmbprovincias.DropDownList.Columns(1).DataMember = dtUbigeo.Columns("NomProv").ToString
            cmbprovincias.SelectedIndex = 0
            dtUbigeo = Nothing


            dtUbigeo = ObjCliente.MostrarDistritos(cmbdepartamentos.Value, cmbprovincias.Value).Tables(0)
            cmbdistritos.DataSource = dtUbigeo
            cmbdistritos.DropDownList.DataMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.DropDownList.DisplayMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.DropDownList.ValueMember = dtUbigeo.Columns("CodUbigeo").ToString
            cmbdistritos.DropDownList.Columns(0).DataMember = dtUbigeo.Columns("CodDist").ToString
            cmbdistritos.DropDownList.Columns(1).DataMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.SelectedIndex = 0
            dtUbigeo = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbprovincias_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprovincias.ValueChanged
        Try
            cmbdistritos.Refresh()

            '======================================= DISTRITOS =========================================

            dtUbigeo = ObjCliente.MostrarDistritos(cmbdepartamentos.Value, cmbprovincias.Value).Tables(0)
            cmbdistritos.DataSource = dtUbigeo
            cmbdistritos.DropDownList.DataMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.DropDownList.DisplayMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.DropDownList.ValueMember = dtUbigeo.Columns("CodUbigeo").ToString
            cmbdistritos.DropDownList.Columns(0).DataMember = dtUbigeo.Columns("CodDist").ToString
            cmbdistritos.DropDownList.Columns(1).DataMember = dtUbigeo.Columns("NomDist").ToString
            cmbdistritos.SelectedIndex = 0
            dtUbigeo = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try

            CodUbigeo = cmbdistritos.Value
            Nombre = Trim(cmbdepartamentos.Text) & " - " & Trim(cmbprovincias.Text) & " - " & Trim(cmbdistritos.Text)
            Departamento = Trim(cmbdepartamentos.Value)
            Provincia = Trim(cmbprovincias.Value)
            Distrito = Trim(cmbdistritos.Value)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class