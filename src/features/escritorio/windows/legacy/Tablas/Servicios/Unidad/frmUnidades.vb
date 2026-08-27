Imports System.ServiceModel
Imports System.Net.Mail
Public Class frmUnidades

    Private oVehiculoService As New VehiculoService.VehiculoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtAreas As DataTable

    Private state_Search As Boolean

    Private Sub frmUnidades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVehiculoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oVehiculoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oVehiculoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmUnidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 133)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()


    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oVehiculoService.FiltrarUnidad(Session.sCodEmp, cmbCodArea.Value, txtSerie.Text, txtMarca.Text, txtPlaca.Text).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo2()
        Try

            Dim SendFrom As MailAddress = New MailAddress("cmateu@equimap.com.pe")
            Dim SendTo As MailAddress = New MailAddress("cmateu@equimap.com.pe")
            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
            'If toBlank(txtcc.Text) <> "" Then
            '    MyMessage.CC.Add(txtcc.Text)
            'End If
            MyMessage.Subject = "titulo"
            MyMessage.Body = "body"

            'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\" & Session.sRucEmp & "-01-" & Documento & ".zip"
            Dim xmldir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & "F001-17820" & "\" & "20554369759" & "-01-" & "F001-17820" & ".xml"
            Dim pdfdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & "F001-17820" & "\" & "20554369759" & "-01-" & "F001-17820" & ".pdf"

            'Dim destdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".zip"
            'Dim xmldir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".xml"
            'Dim pdfdir As String = "D:\Documentos_Electronicos\Facturas_Electronicas\" & Documento & "\20100020441-01-" & Documento & ".pdf"

            Dim attachFile As Attachment = New Attachment(xmldir)
            MyMessage.Attachments.Add(attachFile)
            Dim attachFile1 As Attachment = New Attachment(pdfdir)
            MyMessage.Attachments.Add(attachFile1)

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = Session.sMailHost  '"mail.ddperu.com.pe"
            smtp.Credentials = New System.Net.NetworkCredential(Session.sCorreoEmisor, Session.sClaveCorreoEmisor) 'New System.Net.NetworkCredential("facturacion@ddperu.com.pe", "Facturacion$2002")
            smtp.Send(MyMessage)
            MsgBox("Se envio el correo correctamente", MsgBoxStyle.Information)


            'Dim frm As New frmUnidad
            'frm.state_button = False
            'frm.IdProveedor = 0
            'frm.btnEditar.Enabled = False
            'frm.btnCancelar.Enabled = False
            'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '    dtDatos = Nothing
            '    limpiaOpcionesBusqueda("insert", frm.IdProveedor)
            '    listaDatos()
            '    If frm.type_process = "insert" Then
            '        RowPossesion(dgvDatos, frm.IdProveedor)
            '        mostrar()
            '    End If
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO PROVEEDOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()

        Dim frm As New frmUnidad
        frm.state_button = False
        frm.edicion = True
        frm.editable = True
        frm.Placa = ""
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            If frm.type_process = "insert" Then
                RowPossesion(dgvDatos, frm.Placa)
                mostrar()
            End If
        End If

    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmUnidad
            frm.state_button = True
            frm.Placa = toBlank(dgvDatos.CurrentRow.Cells("Placa").Value)
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtPlaca.Text.Trim)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.Placa)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
                'listaDatos()
            End If
            actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("Placa").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("Placa").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub biactualizar_Click(sender As Object, e As EventArgs) Handles biactualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Unidad con Placa = " + dgvDatos.CurrentRow.Cells("Placa").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oVehiculoService.BorrarUnidad(dgvDatos.CurrentRow.Cells("Placa").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA UNIDAD :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("Placa").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
    End Sub

End Class