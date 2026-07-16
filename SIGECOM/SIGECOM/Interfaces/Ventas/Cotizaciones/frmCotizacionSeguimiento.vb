
Imports System.Windows.Forms
Imports System.Net

Public Class frmCotizacionSeguimiento
    Private ObjCotizacion As New CotizacionService.CotizacionServiceClient
    Private dtDatos As DataTable
    Public IdCotizacion As Integer
    Public NumCot As Integer
    Public cliente As String

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
            
        End If
    End Sub

    Private Sub frmCotizacionSeguimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaDatos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjCotizacion) = False Then
                ObjCotizacion.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
   
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miActualizar.Enabled = False
            miImprimir.Enabled = False

            biMostrar.Enabled = False
            biactualizar.Enabled = False
            biImprimir.Enabled = False

        Else
            miMostrar.Enabled = True
            miActualizar.Enabled = True
            miImprimir.Enabled = True

            biMostrar.Enabled = True
            biactualizar.Enabled = True
            biImprimir.Enabled = True

        End If
    End Sub
    Private Sub Nuevo()
        Try

            Dim frm As New frmCotizacionesSeguimientos
            
            frm.state_button = False
            frm.IdCotizacion = IdCotizacion
            frm.txtNumCot.Text = NumCot
            frm.IdHisCoti = 0
            'frm.txtIdHisCoti.Visible = False
            'frm.lblHistorial.Visible = False
            'frm.txtCodUsu.Visible = False
            'frm.lblUsuario.Visible = False
            'frm.lblPc.Visible = False
            'frm.txtNomPc.Visible = False
            frm.lblCliente.Text = "CLIENTE: " & cliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, dtDatos, "IdCotizacion", frm.IdCotizacion)
                    'mostrar()
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrar()
        Try
            Dim frm As New frmCotizacionesSeguimientos
           
            frm.state_button = True
            frm.IdCotizacion = IdCotizacion
            frm.NumCot = NumCot
            frm.IdHisCoti = dgvDatos.CurrentRow.Cells("IdHisCoti").Text
            frm.lblCliente.Text = "CLIENTE: " & cliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing

                listaDatos()
                'RowPossesion(dgvDatos, dtDatos, "IdCotizacion", frm.IdCotizacion)
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()

        Try
            dtDatos = ObjCotizacion.MostrarHistoriaCotizacion(IdCotizacion).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            sslTotal.Text = "Observaciones : " + dgvDatos.RowCount.ToString
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdCotizacion", codigo)
        End If
    End Sub
    Private Sub imprimir()

    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()

    End Sub


    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        mostrar()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        mostrar()

    End Sub


    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()

    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()

    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        mostrar()

    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()

    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Observacion."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Observacion Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Observaciones del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Observaciones ."
    End Sub
  
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, _
                                    biactualizar.MouseLeave, biCancelar.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

   
End Class