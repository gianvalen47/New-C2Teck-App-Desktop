Imports System.ServiceModel

Public Class frmComCotizacionSolicitud

    Private oCotizacionSolicitudService As New CotizacionSolicitudService.CotizacionSolicitudServiceClient
    Private oCotizacionSolicitudDetService As New CotizacionSolicitudDetService.CotizacionSolicitudDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContactoProveedorService As New ContactoProveedorService.ContactoProveedorServiceClient
    Private oSolicitudCompraDetService As New SolicitudCompraDetService.SolicitudCompraDetServiceClient

    Public state_button As Boolean    '---True =Modificar      False =Nuevo
    Public IdCotizacion As Integer
    Private IdProveedor As Integer

    Private dtDatos As DataTable
    Private dtMoneda As DataTable
    Private dtSolicitud As DataTable
    Private dtContacto As DataTable

    Private DirFile As String
    Private fileExt As String
    Private dtLimite As Integer


    Private Sub frmComCotizacionSolicitud_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oCotizacionSolicitudService.Close()
            oCotizacionSolicitudDetService.Close()
            oMaestroService.Close()
            oContactoProveedorService.Close()

        Catch ex As TimeoutException
            oCotizacionSolicitudService.Abort()
            oCotizacionSolicitudDetService.Abort()
            oMaestroService.Abort()
            oContactoProveedorService.Abort()

        Catch ex As CommunicationException
            oCotizacionSolicitudService.Abort()
            oCotizacionSolicitudDetService.Abort()
            oMaestroService.Abort()
            oContactoProveedorService.Abort()

        Catch ex As Exception
            GC.SuppressFinalize(Me)
        End Try

    End Sub

    Private Sub frmComCotizacionSolicitud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComCotizacionSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumCotizacion.KeyPress _
        , cbFecha.KeyPress _
        , cmbCodMon.KeyPress _
        , cmbSolicitud.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmComCotizacionSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Estilo As New Estilo
            Estilo.cargaEstiloGridExtAlternating(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
            llenarCombos()
            If state_button Then
                ObtenerRegistro()
                Desactivar()
                listaDatos()
                enableOpciones()
                dgvDatos.Visible = True
                Me.Text = "Cotización N°: " & txtNumCotizacion.Text
            Else
                cbFecha.Value = Today
                cmbCodMon.Value = "NS"
                txtIgv.Value = oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "Igv", "IdLocacion", "1")
                dgvDatos.Visible = False
                Me.Size = New System.Drawing.Size(675, 190)
                enableOpciones()
                Me.Text = "Crear cotización de solicitud de compra"
            End If
        Catch ex As Exception
            MsgBox("Error al cargar al load : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If CInt(row.Cells("IdCotizacionDet").Value) = codigo Then
                lista.Row = row.Position
                lista.Col = 1

            End If
        Next

    End Sub
    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount > 0 Then                
                miModificar.Enabled = True
                miEliminar.Enabled = True
            Else
                miModificar.Enabled = False
                miEliminar.Enabled = False
            End If

            biGuardar.Enabled = IIf(state_button, False, True)
            biEditar.Enabled = IIf(state_button, True, False)
            biDeshacer.Enabled = IIf(state_button, False, True)
            biDescargarExcel.Enabled = IIf(state_button, True, False)
            biImportarExcel.Enabled = IIf(state_button, True, False)
            biSalir.Enabled = IIf(state_button, True, False)

        Catch ex As Exception
            MsgBox("Error al habilitar las opciones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMoneda
            cmbCodMon.DropDownList.DataMember = dtMoneda.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMoneda.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMoneda.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMoneda.Columns("AbrMon").ToString
            dtMoneda = Nothing

            dtSolicitud = oCotizacionSolicitudService.MostrarSolicitudPendiente.Tables(0)
            cmbSolicitud.DataSource = dtSolicitud
            cmbSolicitud.DropDownList.DataMember = dtSolicitud.Columns("IdSolicitud").ToString
            cmbSolicitud.DropDownList.DisplayMember = dtSolicitud.Columns("IdSolicitud").ToString
            cmbSolicitud.DropDownList.ValueMember = dtSolicitud.Columns("IdSolicitud").ToString
            cmbSolicitud.DropDownList.Columns(0).DataMember = dtSolicitud.Columns("IdSolicitud").ToString
            cmbSolicitud.DropDownList.Columns(1).DataMember = dtSolicitud.Columns("ApeNom").ToString
            dtSolicitud = Nothing

        Catch ex As Exception
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaContactos()
        Try
            dtContacto = oContactoProveedorService.Mostrar(IdProveedor).Tables(0)
            cmbContacto.DataSource = dtContacto
            cmbContacto.DropDownList.DataMember = dtContacto.Columns("Nombres").ToString
            cmbContacto.DropDownList.DisplayMember = dtContacto.Columns("Nombres").ToString
            cmbContacto.DropDownList.ValueMember = dtContacto.Columns("IdContacto").ToString
            cmbContacto.DropDownList.Columns(0).DataMember = dtContacto.Columns("IdContacto").ToString
            cmbContacto.DropDownList.Columns(1).DataMember = dtContacto.Columns("Nombres").ToString
            cmbContacto.DropDownList.Columns(2).DataMember = dtContacto.Columns("Apellidos").ToString
            dtContacto = Nothing

        Catch ex As Exception
            MsgBox("Error al listar los contactos del prooveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CotizacionSolicitudService.CotizacionSolicitud
            registro = oCotizacionSolicitudService.Obtener(IdCotizacion)

            txtNumCotizacion.Text = registro.NumCotizacion
            cbFecha.Value = registro.Fecha
            cmbCodMon.Value = registro.Moneda.CodMon
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            listaContactos()
            cmbContacto.Value = registro.ContactoProveedor.IdContacto
            cmbSolicitud.Value = registro.SolicitudCompra.IdSolicitud
            txtIgv.Value = registro.Igv

        Catch ex As Exception
            MsgBox("Error al obtener registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As CotizacionSolicitudService.CotizacionSolicitud)
        Try
            Dim estado_process As Integer
            estado_process = oCotizacionSolicitudService.Insertar(registro)
            If estado_process > 0 Then
                MsgBox("Se insertó el registro correctamente")
                IdCotizacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("Error en el proceso, comunicarse con el administrador del sistema", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error al insertar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CotizacionSolicitudService.CotizacionSolicitud)
        Try
            Dim estado_proecess As Boolean
            estado_proecess = oCotizacionSolicitudService.Actualizar(registro)
            If estado_proecess Then
                MsgBox("Se modificó los datos correctamente")
                ObtenerRegistro()
                Desactivar()
            Else
                MsgBox("Error en el proceso, comunicarse con el administrador del sistema", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumCotizacion.Text) = "" Then
                MsgBox("Debe ingresar el número de la cotización")
                txtNumCotizacion.Focus()
                Return False
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe ingresar la moneda")
                cmbCodMon.Focus()
                Return False
            ElseIf txtIgv.Value < 0 Then
                MsgBox("El Igv no puede ser menor que cero, Tenga cuidado")
                txtIgv.Focus()
                Return False
            ElseIf toNumber(cmbSolicitud.Value) = 0 Then
                MsgBox("Debe ingresar la solicitud de compra")
                cmbSolicitud.Focus()
                Return False
            ElseIf IdProveedor = 0 Then
                MsgBox("Debe ingresar el proveedor")
                txtProveedor.Focus()
                Return False
            ElseIf toNumber(cmbContacto.Value) = 0 Then
                MsgBox("Debe ingresar el contacto del proveedor")
                cmbContacto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al validar los campos : " + ex.Message)
        End Try
    End Function

    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionSolicitudDetService.Mostrar(IdCotizacion).Tables(0)
            DataGridView2.DataSource = dtDatos
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("Error al listar datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Desactivar()
        Try
            txtNumCotizacion.ReadOnly = True
            txtNumCotizacion.BackColor = System.Drawing.SystemColors.Control
            cbFecha.ReadOnly = True
            cbFecha.BackColor = System.Drawing.SystemColors.Control
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            txtIgv.ReadOnly = True
            txtIgv.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = False
            cmbSolicitud.ReadOnly = True
            cmbSolicitud.BackColor = System.Drawing.SystemColors.Control
            cmbContacto.ReadOnly = True
            cmbContacto.BackColor = System.Drawing.SystemColors.Control
            btnAgregarContacto.Enabled = False

            biGuardar.Enabled = False
            biDeshacer.Enabled = False
            biEditar.Enabled = True
            biSalir.Enabled = True

        Catch ex As Exception
            MsgBox("Error al desactivar los botones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Activar()
        Try
            txtNumCotizacion.ReadOnly = False
            txtNumCotizacion.BackColor = System.Drawing.SystemColors.Window
            cbFecha.ReadOnly = False
            cbFecha.BackColor = System.Drawing.SystemColors.Window
            cmbCodMon.ReadOnly = False
            cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            txtIgv.ReadOnly = True
            txtIgv.BackColor = System.Drawing.SystemColors.Control
            btnBuscarProveedor.Enabled = True
            cmbSolicitud.ReadOnly = True
            cmbSolicitud.BackColor = System.Drawing.SystemColors.Control
            cmbContacto.ReadOnly = False
            cmbContacto.BackColor = System.Drawing.SystemColors.Window
            btnAgregarContacto.Enabled = True

            biGuardar.Enabled = True
            biDeshacer.Enabled = True
            biEditar.Enabled = False
            biSalir.Enabled = False

        Catch ex As Exception
            MsgBox("Error al activar los botones : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim registro As New CotizacionSolicitudService.CotizacionSolicitud
                Dim proveedor As New CotizacionSolicitudService.Proveedor
                Dim moneda As New CotizacionSolicitudService.Moneda
                Dim solicitudcompra As New CotizacionSolicitudService.SolicitudCompra
                Dim contactoproveedor As New CotizacionSolicitudService.ContactoProveedor

                registro.IdCotizacion = IdCotizacion
                registro.NumCotizacion = toBlank(txtNumCotizacion.Text)
                registro.Fecha = cbFecha.Value
                registro.Igv = toNumber(txtIgv.Value)
                proveedor.IdProveedor = IdProveedor
                registro.Proveedor = proveedor
                moneda.CodMon = cmbCodMon.Value
                registro.Moneda = moneda
                solicitudcompra.IdSolicitud = toNumber(cmbSolicitud.Value)
                registro.SolicitudCompra = solicitudcompra
                contactoproveedor.IdContacto = toNumber(cmbContacto.Value)
                registro.ContactoProveedor = contactoproveedor
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then
                    Modificar(registro)
                Else
                    Insertar(registro)
                End If

            End If
         
        Catch ex As Exception
            MsgBox("Error al guardar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Try
            Activar()

        Catch ex As Exception
            MsgBox("Error al editar los datos : " + ex.Message, MsgBoxStyle.Exclamation)

        End Try
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        Try
            If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If state_button Then
                    ObtenerRegistro()
                    Desactivar()
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()
                End If
            End If
          
        Catch ex As Exception
            MsgBox("Error al deshacer los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.codigo
                txtProveedor.Text = frm.descripcion
                listaContactos()
                txtProveedor.Focus()
            End If

        Catch ex As Exception
            MsgBox("Error al buscar el proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.Click
        Try
          
            Dim frm As New frmComCotizacionSolicitud_AgregarDetalle
            frm.IdCotizacionDet = dgvDatos.CurrentRow.Cells("IdCotizacionDet").Text
            If dgvDatos.RowCount > 0 Then
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    miActualizar_Click(sender, e)
                End If
            Else
                MsgBox("No existen registros que mostrar , Verifique")
            End If

        Catch ex As Exception
            MsgBox("Error al modificar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try

            If MsgBox("¿Está seguro de ELIMINAR el código N°:" & dgvDatos.CurrentRow.Cells("CodMer").Text & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim estado_process As Boolean
                estado_process = oCotizacionSolicitudDetService.Borrar(dgvDatos.CurrentRow.Cells("IdCotizacion").Text, dgvDatos.CurrentRow.Cells("IdCotizacionDet").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se eliminó el código de la mercaderia correctamente ")
                    miActualizar_Click(sender, e)
                Else
                    MsgBox("Error en el proceso, cominicarse con el administrador del sistema")
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al eliminar los datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Try

            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                codigo = dgvDatos.CurrentRow.Cells("IdCotizacionDet").Value
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If

        Catch ex As Exception
            MsgBox("Error al Actualizar los Datos : " + ex.Message)
        End Try
    End Sub

    Private Sub miAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAsignar.Click

        Try

            If dgvDatos.RowCount > 0 Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                Dim Cadena As String = ""
                rows = dgvDatos.GetRows()
                Dim row As Janus.Windows.GridEX.GridEXRow

                'If rows.Count <> 0 Then
                For Each row In rows

                        Dim estado_process As Boolean

                        estado_process = oSolicitudCompraDetService.AsignarCotizacion(row.Cells("IdCotizacionDet").Text, row.Cells("IdCotizacion").Text, row.Cells("IdSolicitud").Text, row.Cells("IdSolicitudDet").Text, row.Cells("Observacion").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        ''Cadena = row.Cells("IdOrdenDet").Text

                        'Dim registro As New MoviAlmacenDetService.MoviAlmacenDet
                        'Dim movimiento As New MoviAlmacenDetService.MoviAlmacen
                        'Dim mercaderia As New MoviAlmacenDetService.Mercaderia
                        'Dim ordencompradet As New MoviAlmacenDetService.OrdenesCompraDet

                        'registro.IdMovimientoDet = 0
                        'movimiento.IdMovimiento = IIf(toNumber(IdMovimiento) = 0, Nothing, IdMovimiento)
                        'registro.MoviAlmacen = movimiento
                        'mercaderia.CodMer = row.Cells("CodMer").Text
                        'registro.Mercaderia = mercaderia
                        'ordencompradet.IdOrdenDet = row.Cells("IdOrdenDet").Text
                        'registro.OrdenesCompraDet = ordencompradet
                        'registro.CanMer = toNumber(row.Cells("CanRec").Text)  'toNumber(row.Cells("CanMer").Text)
                        'registro.PreMer = toDouble(row.Cells("PreMer").Text)
                        'registro.DscMer = toDouble(row.Cells("DscMer").Text)

                        'Dim estado_process As Boolean
                        ''estado_process = oMoviAlmacenDetService.Insertar(registro, Session.sCodUsu)
                    Next

                    MsgBox("Se insertaron los detalles de la Orden de Compra", MsgBoxStyle.Information)

                    'Else
                    '    MsgBox("Debe seleccionar alguno de los correos")
                    'End If
                End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        miModificar_Click(sender, e)
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            miModificar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtIgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIgv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbSolicitud.Select()
            cmbSolicitud.DroppedDown = True
            e.Handled = True
        End If
    End Sub

    Private Sub cmbContacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbContacto.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarContacto.Enabled = True Then
                e.Handled = True
                btnAgregarContacto_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbContacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                e.Handled = True
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbContacto.Select()
            cmbContacto.DroppedDown = True
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        Try
            If IdProveedor > 0 Then
                Dim frm As New frmProveedor_AgregarContacto

                frm.IdProveedor = IdProveedor
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaContactos()
                    cmbContacto.Select()
                    cmbContacto.DroppedDown = True
                End If
            Else
                MsgBox("Debe ingresar el proveedor")
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el contacto : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                biGuardar.MouseLeave, biEditar.MouseLeave, biDeshacer.MouseLeave, _
                                biSalir.MouseLeave, _
                                miModificar.MouseLeave, miEliminar.MouseLeave, _
                                miActualizar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Guardar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.MouseEnter
        sslError.Text = "Guardar los datos ."
    End Sub
    Private Sub Editar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar Cotización de Compra."
    End Sub
    Private Sub Deshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer Cambios Realizados."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Salir de la ventana actual."
    End Sub
   
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar los datos."
    End Sub

    Private Sub Modificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModificar.MouseEnter
        sslError.Text = "Modificar el detalle seleccionado."
    End Sub

    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar el detalle seleccionado."
    End Sub

    Private Sub biDescargarExcel_Click(sender As Object, e As EventArgs) Handles biDescargarExcel.Click

        Dim dtExcel As New DataTable("tabla2")
        dtExcel.Columns.Add(New DataColumn("IdCotizacionDet", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("IdSolicitudDet", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("IdCotizacion", Type.GetType("System.Int32")))
        dtExcel.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("FecEntrega", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
        dtExcel.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
        If dgvDatos.RowCount > 0 Then

            For i As Integer = 0 To dtDatos.Rows.Count - 1
                dtExcel.Rows.Add(New Object() {toNumber(dtDatos.Rows(i).Item(0)), toNumber(dtDatos.Rows(i).Item(3)), toNumber(dtDatos.Rows(i).Item(1)), dtDatos.Rows(i).Item(4), toBlank(dtDatos.Rows(i).Item(5)), toDouble(dtDatos.Rows(i).Item(6)), "", "0.00", "0.00", ""})
            Next

        End If

        'dtExcel.Rows.Add(New Object() {"", "", "0.00", "", "UND", ""})

        DataGridView2.DataSource = dtExcel
        Dim Export As Boolean
        Export = ExportarExcel(DataGridView2)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub biImportarExcel_Click(sender As Object, e As EventArgs) Handles biImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.Filter = "xlsx|*.xlsx"
        'OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()


        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            'Dim fileExt As String
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xlsx") Then '' (fileExt <> ".xls") Then
                MsgBox("Solo se aceptan archivos de Excel, tenga cuidado !!!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
            'CreacionTable()
            If dgvDatos.RowCount >= 280 Then
                MsgBox("Solo se permiten 279 filas para un Ingreso Masivo !!!", MsgBoxStyle.Information)
            Else
                InsertarMasivo()
            End If
        End If

    End Sub

    Private Sub CargarGrilla()
        DataGridView1.DataSource = GetDataExcel(DirFile, fileExt)
    End Sub

    Private Sub InsertarMasivo()
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 2


                If IsDBNull(DataGridView1.Item(0, i).Value) = False Then

                    Dim registro As New CotizacionSolicitudDetService.CotizacionSolicitudDet
                    Dim solicitudcompradet As New CotizacionSolicitudDetService.SolicitudCompraDet
                    Dim cotizacionsolicitud As New CotizacionSolicitudDetService.CotizacionSolicitud

                    registro.IdCotizacionDet = DataGridView1.Item(0, i).Value
                    solicitudcompradet.IdSolicitudDet = DataGridView1.Item(1, i).Value
                    registro.SolicitudCompraDet = solicitudcompradet
                    cotizacionsolicitud.IdCotizacion = DataGridView1.Item(2, i).Value
                    registro.CotizacionSolicitud = cotizacionsolicitud
                    registro.CanMer = toDouble(DataGridView1.Item(5, i).Value)
                    registro.FecEntrega = IIf(IsDBNull(DataGridView1.Item(6, i).Value), Nothing, DataGridView1.Item(6, i).Value)      'IIf(txtFecEntrega.Text = "", Nothing, txtFecEntrega.Value)
                    registro.PreMer = toDouble(DataGridView1.Item(7, i).Value)
                    registro.DscMer = toDouble(DataGridView1.Item(8, i).Value)
                    registro.Observacion = IIf(IsDBNull(DataGridView1.Item(9, i).Value), "", DataGridView1.Item(9, i).Value)
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Modificar(registro)

                End If
            Next

            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar Excel : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CotizacionSolicitudDetService.CotizacionSolicitudDet)
        Try
            Dim estado_process As Boolean
            estado_process = oCotizacionSolicitudDetService.Actualizar(registro)
            If estado_process Then
                'MsgBox("Se actualizó el registro correctamente")
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("Error al modificar el detalle : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub Insertar(ByVal registro As SolicitudCompraDetService.SolicitudCompraDet)

    '    Try
    '        Dim estado_process As Integer
    '        estado_process = oSolicitudCompraDetService.Insertar(registro)

    '        If estado_process > 0 Then

    '        Else
    '            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

End Class