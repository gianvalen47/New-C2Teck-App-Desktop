Imports System.ServiceModel
Public Class frmDespachoDetalle

    '===========================Servicios====================================
    Private oDespachoDetService As New DespachoDetService.DespachoDetServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete

    Public IdDespachoCab As Integer
    Public IdDespachoDet As Integer
    Public iEstado As Integer

    Private IdCliente As Integer
    Private IdSerieDocumento As Integer

    Private IdGuia As Integer
    Private CodSerie As String
    Private NumDoc As String

    Private Sub frmDespachoDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDespachoDetService.Close()
            oGuiaRemisionService.Close()
        Catch ex As TimeoutException
            oDespachoDetService.Abort()
            oGuiaRemisionService.Abort()
        Catch ex As CommunicationException
            oDespachoDetService.Abort()
            oGuiaRemisionService.Abort()
        End Try
    End Sub

    Private Sub frmDespachoDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDespachoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then    'Modificar
            ObtenerRegistro()
            btnBuscarguia.Enabled = False
            'desactivar()
        Else                          'Nuevo
            btnBuscarguia.Focus()
            btnBuscarguia.Enabled = True
            btnBuscarguia.Select()
            'activar()
        End If

        If iEstado = 1 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As DespachoDetService.DespachoDet
            registro = oDespachoDetService.Obtener(toNumber(IdDespachoDet))

            IdDespachoDet = registro.IdDespachoDet
            IdDespachoCab = registro.DespachoCab.IdDespachoCab

            IdSerieDocumento = registro.SerieDocumento.IdSerieDoc
            txtNumGuia.Text = registro.NumDoc
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            txtDestino.Text = registro.Destino
            txtTransporte.Text = registro.AgenciaTransp
            txtCanBultos.Text = registro.CanBultos
            txtObservacion.Text = registro.Observacion
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarguia_Click(sender As Object, e As EventArgs) Handles btnBuscarguia.Click
        Dim frm As New frmBuscarGuia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdGuia = frm.idguia
            txtNumGuia.Text = frm.numdoc
            IdSerieDocumento = frm.idseriedoc
            'CodSerie = frm.codserie
            'NumDoc = frm.numdoc
            IdCliente = frm.idcli
            txtCliente.Text = frm.descli
            ObtenerDatosGuia()
            txtTransporte.Select()
            'IdGuiaRem = frm.codigo
            'NumDocGuiaRem = frm.numero
            'txtNumGuia.Text = frm.numero
            'DocumentoRef = frm.docref
            'CodSunatRef = frm.codsunatref
            'DesDocRef = frm.desdocref
        End If
    End Sub

    Private Sub ObtenerDatosGuia()

        Dim registro As GuiaRemisionService.GuiaRemision
        registro = oGuiaRemisionService.MostrarPorId(IdGuia)

        txtDestino.Text = registro.PtoLlegada
        txtCanBultos.Text = registro.NumeroBultos

    End Sub

    Private Sub txtTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransporte.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Select()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnAceptar.Enabled = True Then
                btnAceptar.Select()
                btnAceptar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        'If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
        'And ValidaCampos() Then

        If ValidaCampos() Then

            Dim registro As New DespachoDetService.DespachoDet
            Dim despachocab As New DespachoDetService.DespachoCab
            Dim seriedoc As New DespachoDetService.SerieDocumento
            Dim cliente As New DespachoDetService.Cliente

            registro.IdDespachoDet = IdDespachoDet
            despachocab.IdDespachoCab = IdDespachoCab
            registro.DespachoCab = despachocab

            seriedoc.IdSerieDoc = IdSerieDocumento
            registro.SerieDocumento = seriedoc
            registro.NumDoc = txtNumGuia.Text

            cliente.IdCliente = IdCliente
            registro.Cliente = cliente

            registro.Destino = txtDestino.Text
            registro.AgenciaTransp = txtTransporte.Text
            registro.CanBultos = txtCanBultos.Text
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub

    Private Sub Insertar(ByVal registro As DespachoDetService.DespachoDet)
        Try
            Dim estado_process As Integer
            estado_process = oDespachoDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdDespachoDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As DespachoDetService.DespachoDet)
        Try
            Dim estado_process As Boolean
            estado_process = oDespachoDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumGuia.Text) = "" Then
                MsgBox("Debe ingresar la guia ", MsgBoxStyle.Information, "Información")
                txtNumGuia.BackColor = Color.Red
                txtNumGuia.Focus()
                Return False
            ElseIf toBlank(txtCliente.Text) = "" Then
                MsgBox("Debe ingresar el cliente", MsgBoxStyle.Information, "Información")
                txtObservacion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class