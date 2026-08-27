Imports System.ServiceModel
Public Class frmSerieDocumentos_Nuevo

    Private oSerieDocumentos As New SerieDocumentoService.SerieDocumentoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtTipoMovimientos As DataTable

    Public CodOfi As String
    Public DesOfi As String
    Public CodAlm As String
    Public DesAlm As String
    Public IdLocacion As String

    Private dtSistemas As DataTable
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean ' = True                   'True: Edición      False: Vista
    Public editable As Boolean ' = True          'True: Editable     False: No Editable
    Public IdSerieDoc As Integer

    Private Sub frmSerieDocumentos_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSerieDocumentos.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSerieDocumentos.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSerieDocumentos.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmSerieDocumentos_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biCerrar_Click(sender, e)
        End If
    End Sub

    Private Sub frmSerieDocumentos_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LlenarCombos()
        If state_button Then    'Modificar            
            LimpiarCampos()
            ObtenerRegistro()
            desactivar()
            Me.Text = "Serie Documento : " + Chr(34) + "." + IdSerieDoc.ToString() + "- OFICINA : " + DesOfi + " - ALMACEN : " + DesAlm
        Else 'Nuevo
            'cbActivo.Checked = True
            'txtEmpresa.Focus()
            SugerirNumero()
            LimpiarCampos()
            activar()
            Me.Size = New System.Drawing.Size(557, 239)
            Me.Text = "Registrar nuevo Serie Documento - OFICINA : " + DesOfi + " - ALMACEN : " + DesAlm
            'txtIgv.Text = "0"
        End If

    End Sub

    Private Sub SugerirNumero()

        Dim numsug As Integer
        numsug = oSerieDocumentos.SugerirIdSerieDoc().ToString()
        txtIdSerieDoc.Text = numsug
        'txtIdSerieDoc.Text = x.

    End Sub

    Private Sub LlenarCombos()

        Try

            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oSerieDocumentos.MostrarTipoDocumentoGeneral.Tables(0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing

            'dtTipoDocumentos = oRegistroCompraService.MostrarTipoDocumento().Tables(0)
            'cmbDocu.DataSource = dtTipoDocumentos
            'cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            'cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            'cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            'cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            'cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            'cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            'dtTipoDocumentos = Nothing

            '======================================= TIPO DE MOVIMIENTO ================================================
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "Ingreso"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "Salida"})
            dtTipoMovimientos.Rows.Add(New Object() {"C", "Costo"})
            dtTipoMovimientos.Rows.Add(New Object() {"O", "Otros"})

            cmbTipMov.DataSource = dtTipoMovimientos
            cmbTipMov.DropDownList.DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.DisplayMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.DropDownList.ValueMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(0).DataMember = dtTipoMovimientos.Columns("codigo").ToString
            cmbTipMov.DropDownList.Columns(1).DataMember = dtTipoMovimientos.Columns("nombre").ToString
            cmbTipMov.SelectedIndex = 1
            dtTipoMovimientos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub LimpiarCampos()

        txtCodSerie.Text = ""
        txtDescripcion.Text = ""
        txtNumDoc.Text = ""

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As SerieDocumentoService.SerieDocumento
            registro = oSerieDocumentos.Obtener(IdSerieDoc)

            IdSerieDoc = registro.IdSerieDoc
            txtIdSerieDoc.Text = registro.IdSerieDoc
            IdLocacion = registro.Locacion.IdLocacion
            cmbDocu.Value = registro.TipoDocumento.IdDocumento
            cmbTipMov.Value = registro.TipMov
            'txtIdSerieDoc.Text = registro.IdSerieDoc
            txtCodSerie.Text = registro.CodSerie
            txtDescripcion.Text = registro.Descripcion
            txtNumDoc.Text = registro.NumDoc
            'txtClaveOSE.Text = registro.ClaveOSE

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub activar()

        biEditarr.Enabled = False
        biDeshacerr.Enabled = True
        biGuardar.Enabled = True


        cmbDocu.ReadOnly = False
        cmbDocu.BackColor = System.Drawing.SystemColors.Window
        cmbTipMov.ReadOnly = False
        cmbTipMov.BackColor = System.Drawing.SystemColors.Window

        txtIdSerieDoc.ReadOnly = False
        txtIdSerieDoc.BackColor = System.Drawing.SystemColors.Window
        txtCodSerie.ReadOnly = False
        txtCodSerie.BackColor = System.Drawing.SystemColors.Window
        txtDescripcion.ReadOnly = False
        txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        txtNumDoc.ReadOnly = False
        txtNumDoc.BackColor = System.Drawing.SystemColors.Window


    End Sub

    Private Sub desactivar()

        biEditarr.Enabled = True
        biDeshacerr.Enabled = False
        biGuardar.Enabled = False

        cmbDocu.ReadOnly = True
        cmbDocu.BackColor = System.Drawing.SystemColors.Control
        cmbTipMov.ReadOnly = True
        cmbTipMov.BackColor = System.Drawing.SystemColors.Control

        txtIdSerieDoc.ReadOnly = True
        txtIdSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtCodSerie.ReadOnly = True
        txtCodSerie.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                 And ValidaCampos() Then

                Dim registro As New SerieDocumentoService.SerieDocumento
                Dim locacion As New SerieDocumentoService.Locacion
                Dim tipodocumento As New SerieDocumentoService.TipoDocumento
                Dim empresa As New SerieDocumentoService.Empresa

                registro.IdSerieDoc = txtIdSerieDoc.Text
                locacion.IdLocacion = IdLocacion
                empresa.CodEmp = Session.sCodEmp
                locacion.Empresa = empresa
                registro.Locacion = locacion
                registro.TipMov = cmbTipMov.Value
                tipodocumento.IdDocumento = cmbDocu.Value
                registro.TipoDocumento = tipodocumento

                registro.CodSerie = txtCodSerie.Text
                registro.Descripcion = txtDescripcion.Text
                registro.NumDoc = txtNumDoc.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS" + ex.Message)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As SerieDocumentoService.SerieDocumento)
        Try
            Dim estado_process As Boolean
            estado_process = oSerieDocumentos.Insertar(registro)
            type_process = "insert"
            If estado_process Then
                MsgBox("Se insertó la Serie Documento correctamente")
                IdSerieDoc = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA SERIE DOCUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SerieDocumentoService.SerieDocumento)
        Try
            Dim estado_process As Boolean
            estado_process = oSerieDocumentos.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se Modifico la Serie Documento correctamente")
                ObtenerRegistro()
                desactivar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA SERIE DOCUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbTipMov.Text) = "" Then
                MsgBox("Debe Ingresar el Tipo Movimiento", MsgBoxStyle.Information, "Información")
                cmbTipMov.BackColor = Color.Red
                cmbTipMov.Focus()
                Return False
            ElseIf toBlank(cmbDocu.Text) = "" Then
                MsgBox("Debe Ingresar el Tipo de Documento", MsgBoxStyle.Information, "Información")
                cmbDocu.BackColor = Color.Red
                cmbDocu.Focus()
                Return False
            ElseIf toBlank(txtCodSerie.Text) = "" Then
                MsgBox("Debe Ingresar el Codigo de la Serie", MsgBoxStyle.Information, "Información")
                txtCodSerie.BackColor = Color.Red
                txtCodSerie.Focus()
                Return False
            ElseIf toBlank(txtDescripcion.Text) = "" Then
                MsgBox("Debe Ingresar la Descripción.", MsgBoxStyle.Information, "Información")
                txtDescripcion.BackColor = Color.Red
                txtDescripcion.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe Ingresar el Numero de Documento", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If

            Return True

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.Close()
    End Sub

    Private Sub biEditarr_Click(sender As Object, e As EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub biDeshacerr_Click(sender As Object, e As EventArgs) Handles biDeshacerr.Click
        desactivar()
    End Sub


End Class