Imports System.ServiceModel
Public Class frmLocaciones_Nuevo

    Private oLocacionService As New LocacionService.LocacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private dtOficinas As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdLocacion As Integer
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmLocaciones_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oLocacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oLocacionService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmLocaciones_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmLocaciones_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombos()
        If state_button Then    'Modificar            
            ObtenerRegistro()
            desactivar()
            Me.Text = "Locacion :  " + Chr(34) + cmbOficinas.Text.ToString + Chr(34)
        Else 'Nuevo
            activar()
            Me.Size = New System.Drawing.Size(468, 397)
            Me.Text = "Registrar nueva Locacion"
            SugerirIdLocacion()
            cbActivo.Checked = True
        End If
    End Sub

    Private Sub SugerirIdLocacion()

        Dim numsug As Integer
        numsug = oLocacionService.SugerirIdLocacion().ToString()
        txtIdLocacion.Text = numsug

    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= AREAS ================================================
            dtAlmacenes = oMaestroService.MostrarAlmacenes().Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.SelectedIndex = 0
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True

        txtIdLocacion.ReadOnly = True
        txtIdLocacion.BackColor = System.Drawing.SystemColors.Control
        cmbOficinas.ReadOnly = False
        cmbOficinas.BackColor = System.Drawing.SystemColors.Window
        cmbIdLocacion.ReadOnly = False
        cmbIdLocacion.BackColor = System.Drawing.SystemColors.Window
        cmbCodArea.ReadOnly = False
        cmbCodArea.BackColor = System.Drawing.SystemColors.Window
        cmbCentroCosto.ReadOnly = False
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Window
        txtCodSunat.ReadOnly = False
        txtCodSunat.BackColor = System.Drawing.SystemColors.Window
        txtPartida.ReadOnly = False
        txtPartida.BackColor = System.Drawing.SystemColors.Window

        cbActivo.Enabled = True
        cbAplicaCosteo.Enabled = True
        cbAtenderJob.Enabled = True
        cbImporta.Enabled = True

    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        txtIdLocacion.ReadOnly = True
        txtIdLocacion.BackColor = System.Drawing.SystemColors.Control
        cmbOficinas.ReadOnly = True
        cmbOficinas.BackColor = System.Drawing.SystemColors.Control
        cmbIdLocacion.ReadOnly = True
        cmbIdLocacion.BackColor = System.Drawing.SystemColors.Control
        cmbCodArea.ReadOnly = True
        cmbCodArea.BackColor = System.Drawing.SystemColors.Control
        cmbCentroCosto.ReadOnly = True
        cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        txtCodSunat.ReadOnly = True
        txtCodSunat.BackColor = System.Drawing.SystemColors.Control
        txtPartida.ReadOnly = True
        txtPartida.BackColor = System.Drawing.SystemColors.Control

        cbActivo.Enabled = False
        cbAplicaCosteo.Enabled = False
        cbAtenderJob.Enabled = False
        cbImporta.Enabled = False

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As LocacionService.Locacion
            registro = oLocacionService.Obtener(IdLocacion)

            txtIdLocacion.Text = registro.IdLocacion
            cmbOficinas.Value = registro.Oficina.CodOfi
            cmbIdLocacion.Value = registro.Almacen.CodAlm
            cmbCodArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            cbAplicaCosteo.Checked = registro.AplicaCosteo
            cbAtenderJob.Checked = registro.AteJob
            cbImporta.Checked = registro.Importa
            cbActivo.Checked = registro.Vigente
            txtCodSunat.Text = registro.CodSunat

            If Not (registro.FecBaja.ToString = "") Then
                txtFecBaja.Value = CDate(registro.FecBaja)
                txtFecBaja.Text = registro.FecBaja.ToString
            End If
            If Not (registro.FecActivacion.ToString = "") Then
                txtFecActivacion.Value = CDate(registro.FecActivacion)
                txtFecActivacion.Text = registro.FecActivacion.ToString
            End If

            txtPartida.Text = registro.PuntoPartida

            'registro = oLocacionService.SugerirIdLocacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New LocacionService.Locacion
                Dim empresa As New LocacionService.Empresa
                Dim oficina As New LocacionService.Oficina
                Dim almacen As New LocacionService.Almacen
                Dim centrocosto As New LocacionService.CentroCosto

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

                oficina.CodOfi = cmbOficinas.Value
                registro.Oficina = oficina

                registro.IdLocacion = txtIdLocacion.Text
                almacen.CodAlm = cmbIdLocacion.Value
                registro.Almacen = almacen

                registro.Vigente = cbActivo.Checked

                registro.AplicaCosteo = cbAplicaCosteo.Checked
                registro.AteJob = cbAtenderJob.Checked
                registro.Importa = cbImporta.Checked
                centrocosto.CodCentro = cmbCentroCosto.Value
                registro.CentroCosto = centrocosto

                registro.FecBaja = IIf(cbActivo.Checked = True, Nothing, Date.Today) 'Nothing

                registro.PuntoPartida = txtPartida.Text
                registro.CodSunat = toNull(txtCodSunat.Text)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then    'Modificar
                    Modificar(registro)
                Else                    'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As LocacionService.Locacion)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionService.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la locacion correctamente")
                'IdLocacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LocacionService.Locacion)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                ObtenerRegistro()
                desactivar()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbIdLocacion.Text) = "" Then
                MsgBox("Debe Ingresar la Locacion.", MsgBoxStyle.Information, "Información")
                cmbIdLocacion.BackColor = Color.Red
                cmbIdLocacion.Focus()
                Return False
                'ElseIf toBlank(txtCodAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar el Codigo del Almacen", MsgBoxStyle.Information, "Información")
                '    txtCodAlm.BackColor = Color.Red
                '    txtCodAlm.Focus()
                '    Return False
                'ElseIf toBlank(txtDesAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar la Descripción del Almacen", MsgBoxStyle.Information, "Información")
                '    txtDesAlm.BackColor = Color.Red
                '    txtDesAlm.Focus()
                '    Return False
                'ElseIf toBlank(txtAbrAlm.Text) = "" Then
                '    MsgBox("Debe Ingresar la Abreviatura del Almacen", MsgBoxStyle.Information, "Información")
                '    txtAbrAlm.BackColor = Color.Red
                '    txtAbrAlm.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios Realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbCodArea_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
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

    Private Sub cmbOficinas_ValueChanged(sender As Object, e As EventArgs) Handles cmbOficinas.ValueChanged

        'If toBlank(cmbOficinas.Value) <> "" Then
        '    '======================================= ALMACENES ================================================
        '    'dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
        '    dtAlmacenes = oMaestroService.MostrarAlmacenes().Tables(0)
        '    cmbIdLocacion.DataSource = dtAlmacenes
        '    cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
        '    cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
        '    cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
        '    cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
        '    cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
        '    cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("AproDoc").ToString
        '    cmbIdLocacion.DropDownList.Columns(3).DataMember = dtAlmacenes.Columns("CodAlm").ToString
        '    If dtAlmacenes.Rows.Count > 0 Then
        '        cmbIdLocacion.SelectedIndex = 0
        '    Else
        '        cmbIdLocacion.Value = ""
        '    End If
        '    'dtAlmacenes = Nothing
        'Else
        '    cmbIdLocacion.Value = ""
        'End If
    End Sub
End Class