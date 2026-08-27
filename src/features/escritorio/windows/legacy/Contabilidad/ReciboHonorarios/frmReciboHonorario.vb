Imports System.ServiceModel
Imports System.IO
Imports System.Xml
Public Class frmReciboHonorario


    Private oReciboHonorarioService As New ReciboHonorarioService.ReciboHonorarioServiceClient
    Private oReciboHonorarioDetService As New ReciboHonorarioDetService.ReciboHonorarioDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable

    Private dtMonedas As DataTable
    Private dtDatos As DataTable

    Private NombreArchivo As String
    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdHonorario As Integer
    Private IdProveedor As Integer

    Private Sub frmReciboHonorario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmReciboHonorario_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oReciboHonorarioService.Close()
            oReciboHonorarioDetService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oReciboHonorarioService.Abort()
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oReciboHonorarioService.Abort()
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmReciboHonorario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar

            ObtenerRegistro()
            desactivar()
            actualizar()
        Else                    'Nuevo

            txtPeriodo.Value = Today.Year
            'txtMesRegistro.Text = Format(Month(Today), "00")

            ObtenerIR()
            ObtenerNumRegistro()
            cbAfectoIR.Checked = True
            'cbAnulado.Checked = True
            cmbCodMon.Value = "NS"
            txtFecDoc.Value = Today
            txtFecha.Value = Today
            txtFecPago.Value = Today

            activar()
            txtNumRegistro.Select()
        End If

        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")
        'txtTipoCambio.Text = oReciboHonorarioService.ObtenerIR(Session.sCodEmp)

    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtSerieDoc.KeyPress _
                          , txtFecDoc.KeyPress _
                          , cmbCodMon.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtProveedor.KeyPress _
                          , txtFecha.KeyPress _
                          , txtFecPago.KeyPress _
                          , txtNumRegistro.KeyPress
        ', txtTotEmbarque.KeyPress _
        ', cmbCodMon.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtIR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarProveedor.Enabled = True Then
                btnBuscarProveedor.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ObtenerNumRegistro()

        Try
            Try
                txtNumRegistro.Text = oReciboHonorarioService.ObtenerRegistro(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text)
                txtNumRegistro.Focus()
                txtNumRegistro.SelectAll()
            Catch ex As Exception
                MsgBox("ERROR AL OBTENER Nº  DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerIR()

        Try

            txtIR.Text = oReciboHonorarioService.ObtenerIR(Session.sCodEmp)

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ReciboHonorarioService.ReciboHonorario
            registro = oReciboHonorarioService.Obtener(IdHonorario)

            IdHonorario = registro.IdHonorario

            txtPeriodo.Text = registro.Periodo
            txtMesRegistro.Text = registro.Mes
            txtNumRegistro.Text = registro.NumRegistro

            txtFecDoc.Text = registro.FecDoc
            txtFecha.Text = registro.Fecha
            txtFecPago.Text = registro.FecPago
            cbAfectoIR.Checked = registro.AfectoIR
            cbAnulado.Checked = registro.Anulado

            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc

            DocumentoPdf = registro.DocumentoPdf
            DocumentoXml = registro.DocumentoXml

            txtGlosa.Text = registro.Glosa
            txtIR.Text = registro.IR
            cmbCodMon.Value = registro.Moneda.CodMon
            NombreArchivo = registro.NombreArchivo
            txtPdfFE.Text = registro.NombreArchivo
            txtXmlFE.Text = registro.NombreArchivo

            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv

            txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")

            txtTotSol.Text = registro.TotVentaSol
            txtTotDol.Text = registro.TotVentaDol
            txtTotalIRSol.Text = registro.TotIRSol
            txtTotalIRDol.Text = registro.TotIRDol
            txtTotalNetoSol.Text = registro.TotNetoSol
            txtTotalNetoDol.Text = registro.TotNetoDol

            'Me.Text = "FACTURA AL " & IIf(registro.TipFac = "1", "CREDITO", "CONTADO") & " Nº " & txtNumDoc.Text.ToString
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub desactivar()

        txtPeriodo.ReadOnly = True
        txtPeriodo.BackColor = System.Drawing.SystemColors.Control
        txtMesRegistro.ReadOnly = True
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
        txtNumRegistro.ReadOnly = True
        txtNumRegistro.BackColor = System.Drawing.SystemColors.Control

        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtFecPago.ReadOnly = True
        txtFecPago.BackColor = System.Drawing.SystemColors.Control
        txtIR.ReadOnly = True
        txtIR.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = False
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        '**************************************************************

        btnBuscarXml.Enabled = False
        btnLimpiarXml.Enabled = False
        btnBuscarPdf.Enabled = False
        btnLimpiarPdf.Enabled = False

        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control
        btnModificarGlosa.Enabled = False

        cbAfectoIR.Enabled = False
        cbAnulado.Enabled = False

        edicion = False
        enableOpciones()
        dgvDatos.Select()

    End Sub

    Private Sub activar()

        If state_button Then    'Modificar
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
        Else
            txtPeriodo.ReadOnly = False
            txtPeriodo.BackColor = System.Drawing.SystemColors.Window
            txtMesRegistro.ReadOnly = False
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
            txtNumRegistro.ReadOnly = False
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        End If



        txtSerieDoc.ReadOnly = False
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        txtNumDoc.ReadOnly = False
        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        txtFecDoc.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtFecPago.ReadOnly = False
        txtFecPago.BackColor = System.Drawing.SystemColors.Window
        txtIR.ReadOnly = False
        txtIR.BackColor = System.Drawing.SystemColors.Window
        btnBuscarProveedor.Enabled = True
        cmbCodMon.ReadOnly = False
        cmbCodMon.BackColor = System.Drawing.SystemColors.Window
        '**************************************************************

        btnBuscarXml.Enabled = True
        btnLimpiarXml.Enabled = True
        btnBuscarPdf.Enabled = True
        btnLimpiarPdf.Enabled = True

        txtGlosa.ReadOnly = False
        txtGlosa.BackColor = System.Drawing.SystemColors.Window
        btnModificarGlosa.Enabled = True

        cbAfectoIR.Enabled = True

        If state_button Then    'Modificar
            cbAnulado.Enabled = True
        Else
            cbAnulado.Enabled = False
        End If
        edicion = True
        enableOpciones()
        dgvDatos.Select()

    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdHonorarioDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()

        Try
            dtDatos = oReciboHonorarioDetService.Mostrar(toNumber(IdHonorario)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub enableOpciones()

        Try
            If state_button Then

                biEditar.Enabled = IIf(editable, Not edicion, False)
                biSalir.Enabled = Not edicion
                biGrabar.Enabled = edicion
                biDeshacer.Enabled = edicion

                'cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
                cmOpciones.Enabled = True

                miNuevo.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True

                'miNuevo.Enabled = IIf(lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO", True, False)
                'miMostrar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
                'miEliminar.Enabled = IIf(dgvDatos.RowCount > 0 And (lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)

            Else
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biGrabar.Enabled = True

                biSalir.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdHonorarioDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdHonorario) = 0 Then
                MsgBox("Debe Ingresar el código de la factura.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtSerieDoc.Text) = "" Then
                MsgBox("Debe ingresar la serie del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el proveedor", MsgBoxStyle.Information, "Información")
                Return False

            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGrabar_Click(sender As Object, e As EventArgs) Handles biGrabar.Click

        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim registro As New ReciboHonorarioService.ReciboHonorario
                Dim moneda As New ReciboHonorarioService.Moneda
                Dim proveedor As New ReciboHonorarioService.Proveedor
                Dim empresa As New ReciboHonorarioService.Empresa

                registro.IdHonorario = IdHonorario

                registro.Periodo = txtPeriodo.Text
                registro.Mes = txtMesRegistro.Text
                registro.NumRegistro = txtNumRegistro.Text

                registro.Fecha = txtFecha.Text
                registro.FecDoc = txtFecDoc.Text
                registro.FecPago = txtFecPago.Text
                registro.SerDoc = txtSerieDoc.Text
                registro.NumDoc = txtNumDoc.Text
                registro.IR = txtIR.Text
                registro.TipCam = txtTipoCambio.Text
                moneda.CodMon = cmbCodMon.Value
                registro.Moneda = moneda
                proveedor.IdProveedor = IIf(toNumber(IdProveedor) = 0, Nothing, IdProveedor)
                registro.Proveedor = proveedor

                Dim xmlDoc As New XmlDocument

                Dim count As Integer
                count = txtXmlFE.Text.Split("\").Length - 1
                If count < 1 Then

                    registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, DocumentoXml)
                    registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, DocumentoPdf)
                    registro.NombreArchivo = IIf(txtXmlFE.Text = "", Nothing, NombreArchivo)
                Else
                    If txtXmlFE.Text <> "" Then
                        xmlDoc.Load(txtXmlFE.Text)
                    End If

                    If txtPdfFE.Text <> "" Then
                        Dim rutapdf As New FileStream(txtPdfFE.Text, FileMode.Open, FileAccess.Read)
                        Dim binarioPDF(rutapdf.Length) As Byte
                        rutapdf.Read(binarioPDF, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                        rutapdf.Close()
                        registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, binarioPDF)
                    End If
                    registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, xmlDoc.OuterXml)
                    registro.NombreArchivo = NombreArchivo
                End If
                '-------------------------------------------------------------------------------------------

                registro.Glosa = txtGlosa.Text
                registro.AfectoIR = cbAfectoIR.Checked
                registro.Anulado = cbAnulado.Checked

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa


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
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Insertar(ByVal registro As ReciboHonorarioService.ReciboHonorario)
        Try
            Dim estado_process As Integer
            estado_process = oReciboHonorarioService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdHonorario = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ReciboHonorarioService.ReciboHonorario)
        Try
            Dim estado_process As Boolean
            estado_process = oReciboHonorarioService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                desactivar()
                ObtenerRegistro()
                'ActualizarDetallesCentroCosto()
                'ActualizarDetallesJob()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As Object, e As EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtProveedor.Select()
                    'cmbCondPago.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        If state_button = True Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmReciboHonorario_Detalle
                frm.state_button = False
                frm.edicion = True
                frm.editable = True
                frm.IdHonorario = IdHonorario
                frm.AfectoIR = cbAfectoIR.Checked
                frm.IR = txtIR.Value
                frm.CodMon = cmbCodMon.Value
                frm.TipoCambio = txtTipoCambio.Text
                frm.txtCodCuenta.Select()
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdHonorarioDet)
                        mostrarDetalle()
                        actualizarDetalles()
                    End If
                    enableOpciones()

                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmReciboHonorario_Detalle
            frm.state_button = True
            frm.IdHonorarioDet = dgvDatos.CurrentRow.Cells("IdHonorarioDet").Text
            frm.IdHonorario = IdHonorario
            frm.CodMon = cmbCodMon.Value
            frm.TipoCambio = txtTipoCambio.Text
            frm.AfectoIR = cbAfectoIR.Checked
            frm.IR = txtIR.Value
            frm.editable = True
            frm.edicion = False

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdHonorarioDet)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizarDetalles()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdHonorarioDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oReciboHonorarioDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdHonorarioDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdHonorario").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biEditar_Click(sender As Object, e As EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub biDeshacer_Click(sender As Object, e As EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados...?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub btnBuscarXml_Click(sender As Object, e As EventArgs) Handles btnBuscarXml.Click
        Try
            Dim file As New OpenFileDialog()
            'file.Filter = "Archivo JPG|*.jpg"
            file.Filter = "XML|*.xml"
            If file.ShowDialog() = DialogResult.OK Then

                txtXmlFE.Text = file.FileName
                NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)

            End If

        Catch ex As Exception
            MsgBox("ERROR AL ADJUNTAR EL ARCHIVO XML" + ex.Message)
        End Try

    End Sub

    Private Sub btnLimpiarXml_Click(sender As Object, e As EventArgs) Handles btnLimpiarXml.Click
        txtXmlFE.Text = ""
    End Sub

    Private Sub btnBuscarPdf_Click(sender As Object, e As EventArgs) Handles btnBuscarPdf.Click
        Dim file As New OpenFileDialog()
        file.Filter = "PDF|*.pdf"
        If file.ShowDialog() = DialogResult.OK Then
            txtPdfFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        End If
    End Sub

    Private Sub btnLimpiarPdf_Click(sender As Object, e As EventArgs) Handles btnLimpiarPdf.Click
        txtPdfFE.Text = ""
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtGlosa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
            End If
            txtFecDoc.Select()
        End If
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        If Len(Trim(txtNumDoc.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 8
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop
        End If
        txtFecDoc.Select()
    End Sub

    Private Sub txtNumRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtNumRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistro.Text)
                Do While cant < 6
                    txtNumRegistro.Text = "0" & txtNumRegistro.Text
                    cant = cant + 1
                Loop
                'If oRegistroCompraService.Buscar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text) Then   'If BuscarNumRegistro(txtMesRegistro,txtNumRegistro) Then  
                '    IdCompra = oRegistroCompraService.ObtenerIdCompra(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text)
                '    state_button = True 'Modificar
                '    edicion = False
                '    ObtenerRegistro()
                '    actualizarDetalles()
                '    desactivar()
                '    txtNumRegistro.SelectAll()
                'Else
                '    state_button = False 'Nuevo 
                '    edicion = True
                '    Limpiar()
                '    activar()
                '    txtCodTipoDoc.Focus()
                'End If
            Else
                MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
                txtNumRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistro.Validated
        If Len(Trim(txtNumRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumRegistro.Text)
            Do While cant < 6
                txtNumRegistro.Text = "0" & txtNumRegistro.Text
                cant = cant + 1
            Loop
        Else
            MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
            txtNumRegistro.Focus()
        End If
    End Sub

    Private Sub txtMesRegistro_Click(sender As Object, e As EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtMesRegistro_Validated(sender As Object, e As EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                ObtenerNumRegistro()
            End If
        Else
            MsgBox("Debe ingresar el Mes de Registro", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtMesRegistro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) < 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                    txtMesRegistro.Text = ""
                    txtMesRegistro.Focus()
                Else
                    ObtenerNumRegistro()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    'Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick

    'End Sub

    'Private Sub InhabilitarColumnas()
    '    Try
    '        If cmbCodMon.Value = "NS" Then
    '            dgvDatos.RootTable.Columns(5).Visible = True
    '            dgvDatos.RootTable.Columns(6).Visible = True
    '            dgvDatos.RootTable.Columns(7).Visible = True

    '            dgvDatos.RootTable.Columns(8).Visible = False
    '            dgvDatos.RootTable.Columns(9).Visible = False
    '            dgvDatos.RootTable.Columns(10).Visible = False
    '        ElseIf cmbCodMon.Value = "US" Then
    '            dgvDatos.RootTable.Columns(5).Visible = False
    '            dgvDatos.RootTable.Columns(6).Visible = False
    '            dgvDatos.RootTable.Columns(7).Visible = False

    '            dgvDatos.RootTable.Columns(8).Visible = True
    '            dgvDatos.RootTable.Columns(9).Visible = True
    '            dgvDatos.RootTable.Columns(10).Visible = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL INHABILITAR COLUMNAS : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub cmbCodMon_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodMon.ValueChanged
    '    InhabilitarColumnas()
    'End Sub
End Class