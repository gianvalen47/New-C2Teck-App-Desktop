Imports System.Windows.Forms
Imports System.Net

Public Class frmCotizacionesSeguimientos

    Private ObjCotizacion As New CotizacionService.CotizacionServiceClient
    Public state_button As Boolean
    Public type_process As String
    Private dtDatos As DataTable
    Public IdCotizacion As Integer
    Public NumCot As Integer
    Public IdHisCoti As Integer

    Private Sub frmCotizacionesSeguimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If btnGuardar.Enabled = True Then
                If MsgBox("¿Desea Guardar la Observación?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                    btnGuardar_Click(sender, e)
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub
    
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state_button Then

            ObtenerRegistro()

            txtHora.ReadOnly = True
            txtHora.BackColor = System.Drawing.SystemColors.Control
            'txtIdHisCoti.ReadOnly = True
            'txtIdHisCoti.BackColor = System.Drawing.SystemColors.Control
            txtNumCot.ReadOnly = True
            txtNumCot.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            'txtCodUsu.ReadOnly = True
            'txtCodUsu.BackColor = System.Drawing.SystemColors.Control
            'txtNomPc.ReadOnly = True
            'txtNomPc.BackColor = System.Drawing.SystemColors.Control
            txtObsCotizacion.ReadOnly = True
            txtObsCotizacion.BackColor = System.Drawing.SystemColors.Control
            btnGuardar.Enabled = False
            listaDatos()

        Else

            'txtIdHisCoti.ReadOnly = True
            'txtIdHisCoti.BackColor = System.Drawing.SystemColors.Control
            txtHora.ReadOnly = True
            txtHora.BackColor = System.Drawing.SystemColors.Control
            txtNumCot.ReadOnly = True
            txtNumCot.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            'txtCodUsu.ReadOnly = True
            'txtCodUsu.BackColor = System.Drawing.SystemColors.Control
            'txtNomPc.ReadOnly = True
            'txtNomPc.BackColor = System.Drawing.SystemColors.Control
            'txtFecha.Text = Today
            txtFecha.Text = Session.sFecha
            txtHora.Text = Format(Now, "hh:mm tt")
            txtObsCotizacion.Select()

            Me.Text = "Registrar nueva Observaciòn"
        End If
    End Sub
    Private Sub Insertar(ByVal HistoriaCotizacion As CotizacionService.HistoriaCotizacion)
        Try
            Dim estado_process As Integer
            estado_process = ObjCotizacion.InsertarHistoriaCotizacion(HistoriaCotizacion)
            type_process = "insert"
            If estado_process > 0 Then
                IdCotizacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As New CotizacionService.HistoriaCotizacion
            registro = ObjCotizacion.ObtenerHistoriaCotizacion(IdHisCoti)

            'txtCodUsu.Text = registro.CodUsu
            'txtNomPc.Text = registro.NomPc
            txtObsCotizacion.Text = registro.Observacion
            txtNumCot.Text = NumCot
            txtFecha.Text = Format(registro.Fecha, "dd/MM/yyyy")
            txtHora.Text = Format(registro.Fecha, "hh:mm tt")

            Me.Text = "Observación Nº " + registro.IdHisCoti.ToString
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = ObjCotizacion.MostrarHistoriaCotizacion(toNumber(IdHisCoti)).Tables(0)

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtObsCotizacion.Text) = "" Then
                MsgBox("Debe Ingresar la Observación", MsgBoxStyle.Information, "Información")
                txtObsCotizacion.Focus()
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Try
                Dim NomPc As String = Dns.GetHostName
                Dim HistoriaCotizacion As New CotizacionService.HistoriaCotizacion
                Dim Cotizacion As New CotizacionService.Cotizacion

                Cotizacion.IdCotizacion = IdCotizacion
                HistoriaCotizacion.Cotizacion = Cotizacion
                HistoriaCotizacion.Observacion = txtObsCotizacion.Text
                HistoriaCotizacion.Fecha = txtFecha.Text
                HistoriaCotizacion.CodUsu = Session.sCodUsu
                HistoriaCotizacion.NomPc = NomPc

                Insertar(HistoriaCotizacion)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar la Observacion."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Observacion."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  btnGuardar.MouseLeave, btnCancelar.MouseLeave

        sslError.Text = ""
    End Sub

End Class