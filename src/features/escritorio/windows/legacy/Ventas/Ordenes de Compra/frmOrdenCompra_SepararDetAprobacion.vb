Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmOrdenCompra_SepararDetAprobacion

    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient


    Public type_process As String               'update     insert      delete
    Public lseparar As Boolean
    Public IdOrden As Integer
    Public IdOrdenDet As Integer
    Public estado As String
    Public CanPen As Integer
    Public Nuevo As Boolean

    Private Sub frmOrdenCompra_SepararDetAprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Nuevo = False Then
            ObtenerRegistro()
        End If


        If estado = "GENERADO" Or estado = "GN" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If

        'If CanPen > 0 Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        'End If


    End Sub

    Private Sub frmOrdenCompra_SepararDetAprobacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOrdenCompra_SepararDetAprobacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Try
                oOrdenCompraDetService.Close()
            Catch ex As TimeoutException
                oOrdenCompraDetService.Abort()
            Catch ex As CommunicationException
                oOrdenCompraDetService.Abort()
            End Try

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        If (estado = "PARCIAL" Or estado = "PA") And CanPen <> 0 Then
            txtCanSep.ReadOnly = False
            txtCanSep.BackColor = System.Drawing.SystemColors.Window
            txtFecIniSep.ReadOnly = False
            txtFecIniSep.BackColor = System.Drawing.SystemColors.Window
            txtFecFinSep.ReadOnly = False
            txtFecFinSep.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Else
            txtCanSep.ReadOnly = True
            txtCanSep.BackColor = System.Drawing.SystemColors.Control
            txtFecIniSep.ReadOnly = True
            txtFecIniSep.BackColor = System.Drawing.SystemColors.Control
            txtFecFinSep.ReadOnly = True
            txtFecFinSep.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenCompraDetService.OrdenCompraSeparadoTemp
            registro = oOrdenCompraDetService.ObtenerSeparar(toNumber(IdOrdenDet))

            'CanPen = registro.CanPen

            'If Session.CodPerfil = "02" Or (Session.CodPerfil = "14" And lseparar = True) Then

            txtCanSep.Value = registro.CanSep
            If registro.FecIniSep Is Nothing Then
                    txtFecIniSep.IsNullDate = True
                Else
                    txtFecIniSep.Text = registro.FecIniSep
                End If
                If registro.FecFinSep Is Nothing Then
                    txtFecFinSep.IsNullDate = True
                Else
                    txtFecFinSep.Text = registro.FecFinSep
                End If
                txtObservacion.Text = toBlank(registro.Observacion)
            'End If

        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'If Session.CodPerfil = "02" Or (Session.CodPerfil = "14" And lseparar) Then
        If ValidaAprobacion() Then
                Separar()
            End If
        'End If
    End Sub

    Private Sub Separar()
        Try
            Dim estado_process As Boolean

            Dim registro As New OrdenCompraDetService.OrdenCompraSeparadoTemp
            Dim ordendet As New OrdenCompraDetService.OrdenCompraDet
            Dim orden As New OrdenCompraDetService.OrdenCompra

            'registro.OrdenCompraDet =
            'ordendet.IdOrden = 0
            orden.IdOrden = IdOrden
            ordendet.IdOrdenDet = IdOrdenDet
            ordendet.OrdenCompra = orden
            registro.OrdenCompraDet = ordendet
            registro.CanSep = txtCanSep.Text
            registro.FecIniSep = txtFecIniSep.Value
            registro.FecFinSep = txtFecFinSep.Value
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.Observacion = txtObservacion.Text

            If Nuevo Then
                estado_process = oOrdenCompraDetService.InsertarSeparar(registro)
            Else

                estado_process = oOrdenCompraDetService.ActualizarSeparar(registro)
            End If

            'type_process = "insert"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtCanSep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanSep.Click
        Try
            If txtCanSep.ReadOnly = False Then
                If txtCanSep.Value > 0 Then
                    txtCanSep.BackColor = Color.White
                Else
                    txtCanSep.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ValidaAprobacion() As Boolean
        Try
            Dim frm As New frmOrdenCompra

            If toBlank(txtFecIniSep.Text) = "" Then
                MsgBox("Debe ingresar la fecha de inicio.", MsgBoxStyle.Information, "Información")
                txtFecIniSep.BackColor = Color.Red
                txtFecIniSep.Focus()
                Return False
            ElseIf toBlank(txtFecFinSep.Text) = "" Then
                MsgBox("Debe ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecFinSep.BackColor = Color.Red
                txtFecFinSep.Focus()
                Return False
            ElseIf txtFecIniSep.Value > txtFecFinSep.Value Then
                MsgBox("Fecha INICIAL no puede ser mayor que la fecha FINAL", MsgBoxStyle.Information, "Información")
                txtFecIniSep.Focus()
                Return False
            ElseIf toNumber(txtCanSep.Text) > CanPen Then
                MsgBox("No puede separar mas de la cantidad en la OC", MsgBoxStyle.Information, "Información")
                txtFecIniSep.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                     txtCanSep.KeyPress _
                  , txtFecIniSep.KeyPress _
                  , txtFecFinSep.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class