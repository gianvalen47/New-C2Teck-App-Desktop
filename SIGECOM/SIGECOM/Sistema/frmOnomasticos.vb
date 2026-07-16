Public Class frmOnomasticos

    '=========================== Servicios ====================================
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================== Declaración de Variables ==============================
    Private UbicPers As String
    Public state_Search As Boolean
    Private dtDatos As DataTable

    Private Sub frmCumpleanos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCumpleanos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            dtDatos = oSeguridadService.MostrarOnomasticosEmpresa(Session.sCodEmp).Tables(0)
            dgvOnomasticos.DataSource = dtDatos

            Dim estilo1 As New Estilo
            estilo1.cargaEstiloDataDrid(dgvOnomasticos)

            lblcabecera.Parent = PictureBox1
            lblcabecera.BackColor = Color.Transparent

            lbldetalle.Parent = PictureBox1
            lbldetalle.BackColor = Color.Transparent

            If dtDatos.Rows.Count > 1 Then

                If dtDatos.Rows.Count < 3 Then
                    'Me.Size = New System.Drawing.Size(792, 480)
                    dgvOnomasticos.Height = 250 '706
                    dgvOnomasticos.Width = 706 '333
                    lbldetalle.Location = New Point(37, 380)    '37, 434
                    'btnAceptar.Location = New Point(351, 420)
                Else
                    'Me.Size = New System.Drawing.Size(792, 585)
                End If
                CargarMensajeMas()
            Else
                'Me.Size = New System.Drawing.Size(792, 480)
                dgvOnomasticos.Height = 250 '706
                dgvOnomasticos.Width = 706 '333
                lbldetalle.Location = New Point(37, 380)    '37, 434
                'btnAceptar.Location = New Point(351, 450)

                CargarMensaje()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al obtener los onomasticos")
        End Try

    End Sub

    Private Sub CargarMensaje()

        lblcabecera.Text = "al colaborador: "
        lbldetalle.Text = "Deseamos que disfrute de un dia especial junto a sus seres queridos y compañeros de trabajo." & Environment.NewLine & Environment.NewLine & _
                          "Que la gracia de Dios y su misericordia le permita tener muchos años más de vida" & Environment.NewLine & _
                          "y sobretodo disfrute de mucha salud."

    End Sub

    Private Sub CargarMensajeMas()

        lblcabecera.Text = "a los colaboradores: "
        lbldetalle.Text = "Deseamos que disfruten de un dia especial junto a sus seres queridos y compañeros de trabajo." & Environment.NewLine & Environment.NewLine & _
                          "Que la gracia de Dios y su misericordia les permita tener muchos años más de vida" & Environment.NewLine & _
                          "y sobretodo disfruten de mucha salud."

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class