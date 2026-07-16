Imports System.ServiceModel
Public Class frmComMesaControl_Nuevo

    '============================Servicios===================================
    Private oMesaControlService As New MesaControlService.MesaControlServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    '======================Declaración de Variables==============================   
    Public IdMesa As Integer
    Public IdGasto As Integer
    Public iEstado As Integer
    Private dtMonedas As DataTable
    Public state_button As Boolean    
    Private dtDatos As DataTable
    Public edicion As Boolean
    Public Anio As Integer
    Private Sub frmComMesaControl_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMesaControlService.Close()
            oSolicitudGastoService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oMesaControlService.Abort()
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oMesaControlService.Abort()
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmComMesaControl_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComMesaControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        If state_button Then    'Mostrar
            gbDetalle.Visible = True
            ObtenerMesa()
            ListarDetalles()
            Desactivar()
            lblCredito.Visible = True
            cbProcesarCredito.Visible = True
            gbEstadoMesa.Visible = True
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(762, 275)
            Activar()
            gbDetalle.Visible = False
            lblCredito.Visible = False
            cbProcesarCredito.Visible = False
            gbEstadoMesa.Visible = False
        End If
        EnableOptions()        
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerMesa()
        Try            
            Dim registro As MesaControlService.MesaControl
            registro = oMesaControlService.Obtener(IdMesa)

            IdMesa = registro.IdMesa
            txtIdMesa.Text = registro.IdMesa
            IdGasto = registro.SolicitudGasto.IdGasto
            txtIdGasto.Text = registro.SolicitudGasto.IdGasto
            txtFecha.Value = registro.SolicitudGasto.Fecha
            txtArea.Text = registro.SolicitudGasto.Area.DesArea
            cmbMoneda.Value = registro.SolicitudGasto.Moneda.CodMon
            txtPersonaSolicita.Text = registro.SolicitudGasto.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.SolicitudGasto.PersonaJefe.ApeNom
            cbProcesarCredito.Checked = registro.Credito
            lblEstadoMesa.Text = registro.EstadoMesaControl.DesEstado
            ListarDetalles()
            Dim registro2 As SolicitudGastoService.SolicitudGasto
            registro2 = oSolicitudGastoService.Obtener(toNumber(txtIdGasto.Text))
            lblEstado.Text = registro2.EstadoSolicitudGasto.DesEstado

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER MESA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        If state_button Then
            iEstado = oSolicitudGastoService.ObtenerEstado(IdGasto)
            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            biAprobar.Enabled = IIf(iEstado = 5 Or iEstado = 6 Or iEstado = 7, False, True)
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
            Else
                miMostrar.Enabled = True
            End If
            cmOpciones.Enabled = IIf(Not edicion, True, False)
        Else
            biGuardar.Enabled = True
            biDeshacer.Enabled = True
            biAprobar.Enabled = False
        End If

    End Sub

    Private Sub Desactivar()
        txtIdGasto.ReadOnly = True
        txtIdGasto.BackColor = System.Drawing.SystemColors.Control
        btnBuscarGasto.Enabled = False
        edicion = False
    End Sub

    Private Sub Activar()
        edicion = True
        txtIdGasto.ReadOnly = False
        txtIdGasto.BackColor = System.Drawing.SystemColors.Window
        btnBuscarGasto.Enabled = True
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            registro = oSolicitudGastoService.Obtener(toNumber(txtIdGasto.Text))

            IdGasto = registro.IdGasto
            txtFecha.Value = registro.Fecha
            txtUnidad.Text = oCentroCostoService.ObtenerDesUnidad(registro.Area.CodArea)
            txtArea.Text = registro.Area.DesArea
            cmbMoneda.Value = registro.Moneda.CodMon
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom
            lblEstado.Text = registro.EstadoSolicitudGasto.DesEstado
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtIdGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdGasto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If ValidarCodigo() Then
                ListarDetalles()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Function ValidarCodigo() As Boolean
        Try
            If Len(Trim(txtIdGasto.Text)) > 0 Then
                If (oMesaControlService.BuscarSolicitud(toNumber(txtIdGasto.Text))) Then
                    MsgBox("Número de Solicitud de Gasto ya Ingresado, Verifique")
                    txtIdGasto.Text = ""
                    txtIdGasto.Focus()
                    Limpiar()
                    Return False
                Else
                    If oSolicitudGastoService.ObtenerEstado(toNumber(txtIdGasto.Text)) <> 3 Then
                        MsgBox("Número de Solicitud de Gasto inexistente o No Aprobada, Verifique")
                        txtIdGasto.Text = ""
                        txtIdGasto.Focus()
                        Limpiar()
                        Return False
                    ElseIf oSolicitudGastoDetService.BuscarCuentasVacias(txtIdGasto.Text) Then
                        MsgBox("Solicitud de Gasto sin Número de Cuenta Contable")
                        txtIdGasto.Text = ""
                        txtIdGasto.Focus()
                        Limpiar()
                        'ElseIf oSolicitudGastoService.BuscarDocumentoVacio(txtIdGasto.Text) Then
                        '    MsgBox("Solicitud de Gasto sin Documentación")
                        '    txtIdGasto.Text = ""
                        '    txtIdGasto.Focus()
                        '    Limpiar()
                    Else
                        Return True
                    End If
                End If
            Else
                MsgBox("Ingrese un N° de Solicitud de Gasto")
                txtIdGasto.Text = ""
                txtIdGasto.Focus()
                Limpiar()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL GASTO : " + ex.Message)
        End Try
    End Function

    Private Sub Limpiar()
        IdMesa = 0
        IdGasto = 0
        txtIdGasto.Text = ""
        txtFecha.Value = Today
        txtArea.Text = ""
        cmbMoneda.Text = ""
        txtPersonaSolicita.Text = ""
        txtPersonaAutoriza.Text = ""
        lblEstado.Text = ""
        dtDatos = Nothing
        dgvDatos.DataSource = Nothing
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        Limpiar()
    End Sub

    Private Sub biCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() And ValidarCodigo() Then

                Dim registro As New MesaControlService.MesaControl
                Dim estado As New MesaControlService.EstadoMesaControl
                Dim estadoSol As New MesaControlService.EstadoSolicitudGasto
                Dim gasto As New MesaControlService.SolicitudGasto
                Dim detalle As New MesaControlService.MesaControlDet

                registro.IdMesa = IdMesa
                gasto.IdGasto = IdGasto
                registro.SolicitudGasto = gasto
                registro.FecReg = Today
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc

                If state_button Then            'Modificar                    
                    Modificar(registro)
                Else                                  'Nuevo
                    estado.IdEstado = 1
                    registro.EstadoMesaControl = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR MESA DE CONTROL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If txtIdGasto.Text = "" Then
            MsgBox("Debe ingresar el Nº de Solicitud de Gasto")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Insertar(ByVal registro As MesaControlService.MesaControl)
        Try
            Dim estado_process As Integer
            estado_process = oMesaControlService.Insertar(registro)  
            If estado_process > 0 Then
                IdMesa = estado_process
                Anio = Year(txtFecha.Value)
                MsgBox("Se inserto la Mesa de Control Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MESA DE CONTROL : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As MesaControlService.MesaControl)
        Try
            Dim estado_process As Boolean
            estado_process = oMesaControlService.Actualizar(registro)
            If estado_process = True Then
                MsgBox("Se modifico la Mesa de Control Correctamente")
                Desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR MESA DE CONTROL: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            Dim frm As New frmComMesaControl_Aprobar
            frm.IdMesa = toNumber(txtIdMesa.Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerMesa()
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Mesa de Control : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarGasto.Click
        Dim frm As New frmBuscarSolicitudGasto
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtIdGasto.BackColor = System.Drawing.SystemColors.Control
            txtIdGasto.Text = frm.IdGasto
            If frm.IdGasto <> Nothing Then
                ObtenerRegistro()
            Else
                Limpiar()
            End If
            txtIdGasto.ReadOnly = False
            txtIdGasto.BackColor = System.Drawing.SystemColors.Window
        End If
        txtIdGasto.Select()
    End Sub

    Private Sub ListarDetalles()
        Try
            dtDatos = oMesaControlService.MostrarDetalles(toNumber(txtIdMesa.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DETALLES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGastoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
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
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmComSolicitudGastoDetNew
            frm.state_button = True
            frm.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            frm.estado = 5
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListarDetalles()
                ObtenerRegistro()
                'If frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, frm.IdGastoDet)
                'Else
                '    MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
                'End If
            End If
            RowPossesion(dgvDatos, frm.IdGastoDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
                e.Handled = True
            End If
        End If
    End Sub
End Class