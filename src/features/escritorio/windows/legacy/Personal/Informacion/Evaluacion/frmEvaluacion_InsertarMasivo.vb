Imports System.ServiceModel
Public Class frmEvaluacion_InsertarMasivo

    '===========================Servicios====================================
    Private oEvaluacionService As New EvaluacionService.EvaluacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    '======================Declaración de Variables==============================   
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtPerAutoriza As DataTable


    Private Sub frmEvaluacion_InsertarMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmEvaluacion_InsertarMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmEvaluacion_InsertarMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarCombos()
        Me.Text = "Insertar Evaluaciones de Colaborador Masivo"
    End Sub

    Private Sub LlenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            'dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0            

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        Try
            If cmbCentroCosto.Value <> "" Then
                '==================================== PERSONA AUTORIZA ==========================================
                dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(toBlank(cmbCentroCosto.Value)).Tables(0)
                cmbPerAutoriza.DataSource = dtPerAutoriza
                cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
                cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
                cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
                cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
                cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
                If dtPerAutoriza.Rows.Count > 0 Then
                    cmbPerAutoriza.SelectedIndex = 0
                End If
                dtPerAutoriza = Nothing                
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PERSONA AUTORIZA: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbCentroCosto.Value) = "" Then
                MsgBox("Debe seleccionar el centro de costo. ", MsgBoxStyle.Information, "Información")
                cmbCentroCosto.Focus()
                Return False
            ElseIf toBlank(cmbClase.Value) = "" Then
                MsgBox("Debe seleccionar la clase.", MsgBoxStyle.Information, "Información")
                cmbClase.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False            
            ElseIf toBlank(cmbPerAutoriza.Value) = "" Then
                MsgBox("Debe seleccionar el Jefe de área.", MsgBoxStyle.Information, "Información")
                cmbPerAutoriza.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de INSERTAR las evaluaciones de Colaborador", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() = True Then
                    estado_process = oEvaluacionService.InsertarMasivo(Session.sCodEmp, toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), txtFecha.Value, toNumber(cmbPerAutoriza.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se ingresó las evaluaciones de colaborador correctamente ")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK                
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al insertar las evaluaciones de colaborador masivo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oEvaluacionService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oEvaluacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oEvaluacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub
End Class