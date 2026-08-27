Imports System.ServiceModel
Public Class frmMantOficinaUsuario

    '=========================== Servicios ====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================== Declaración de Variables ==============================
    Private dtAreas As DataTable
    Private dtDatos As DataTable

    Private Sub frmMantUsuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMantUsuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMantUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 123)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()
        cmbArea.Value = "05"
        listaDatos()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub frmCapacitaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              cmbArea.KeyPress _
                            , txtColaborador.KeyPress _
                            , txtUsuario.KeyPress _
                            , cbVigente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub LlenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSeguridadService.FiltrarUsuarios(txtUsuario.Text, txtColaborador.Text, utils.toBlank(cmbArea.Value), cbVigente.Checked).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR USUARIOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbArea.ValueChanged, txtColaborador.TextChanged, txtUsuario.TextChanged, cbVigente.CheckedChanged
        listaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim CodUsuario As String = ""
        CodUsuario = dgvDatos.CurrentRow.Cells("CodUsu").Value

        listaDatos()
        RowPossesion(dgvDatos, CodUsuario)
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click, miEditar.Click
        Dim frm As New frmMantOficinaUsuarioModificar

        If dgvDatos.CurrentRow.Cells("CodUsu").Value = "" Then
            MsgBox("Selecccione un registro, tenga cuidado ...!")
        Else
            frm.CodUsu = dgvDatos.CurrentRow.Cells("CodUsu").Value
            frm.Actualizar = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.CodUsu)
            End If
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.Close()
    End Sub

    Private Sub biMostrarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrarDatos.Click, dgvDatos.DoubleClick, miMostrar.Click
        Dim frm As New frmMantOficinaUsuarioModificar

        If dgvDatos.CurrentRow.Cells("CodUsu").Value = "" Then
            MsgBox("Selecccione un registro, tenga cuidado...!")
        Else
            frm.CodUsu = dgvDatos.CurrentRow.Cells("CodUsu").Value
            frm.Actualizar = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.CodUsu)
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows
            If row.Cells("CodUsu").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                    btnEditar.MouseLeave, biMostrarDatos.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                                    miEditar.MouseLeave, miMostrar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Editar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter, miEditar.MouseEnter
        sslError.Text = "Editar Usuario actual."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrarDatos.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Usuario actual."
    End Sub    
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
End Class