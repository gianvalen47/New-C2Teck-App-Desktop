Public NotInheritable Class frmAyuda_Acerca


    Private Sub frmAyuda_Acerca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAyuda_Acerca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Set the title of the form.
        'Dim ApplicationTitle As String
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle = My.Application.Info.Title
        'Else
        '    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If
        'Me.Text = String.Format("Acerca de SIGECOM ", ApplicationTitle)
        '' Initialize all of the text displayed on the About Box.
        '' TODO: Customize the application's assembly information in the "Application" pane of the project 
        ''    properties dialog (under the "Project" menu).
        'Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = "Version " & My.Application.Info.Version.ToString 'String.Format("Version 1.2.0.0", My.Application.Info.Version.ToString)
        ' Me.LabelCopyright.Text = My.Application.Info.Copyright  '"Derechos Reservados"
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        ''Me.TextBoxDescription.Text = "SIGECOM es un sistema informático de uso específico diseñado con el fin de consultar o informar el control de Inventarios, Ventas y Cuentas Corrientes " 'para llevar un mejor manejo de registros (unidades de información relevante) ordenados y clasificados para su posterior consulta, actualización o cualquier tarea de mantenimiento mediante aplicaciones específicas."
        '' Me.TextBoxDescription.ForeColor = Color.DarkBlue
        ''My.Application.Info.Description
        OKButton.Select()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
