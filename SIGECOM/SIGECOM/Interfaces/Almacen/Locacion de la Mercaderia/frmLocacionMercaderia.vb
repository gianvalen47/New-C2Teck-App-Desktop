Imports System.Windows.Forms

Public Class frmLocacionMercaderia

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMercaderiaService As New ProductoService.ProductoServiceClient  'MercaderiaService.MercaderiaServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLocacion As String
    Public Oficina As String

    Private CodUbicacion As String

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarMercaderia.Enabled = True Then
                btnBuscarMercaderia_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                               txtMinMer.KeyPress _
                          , txtMaxMer.KeyPress _
                          , txtUbiMer.KeyPress _
                          , txtCodMer.KeyPress
        ', txtObsMer.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtObsMer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObsMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGuardar.Enabled = True Then
                btnGuardar.Select()
                btnGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmLocacionMercaderia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()
        If state_button Then    'Modificar

            ObtenerRegistro()

            btnBuscarMercaderia.Enabled = False
            txtCodMer.ReadOnly = True
            'txtUbiMer.ReadOnly = True
            btnBuscarUbicacion.Enabled = False

            txtMinMer.ReadOnly = True
            txtMinMer.BackColor = System.Drawing.SystemColors.Control
            txtMaxMer.ReadOnly = True
            txtMaxMer.BackColor = System.Drawing.SystemColors.Control
            txtObsMer.ReadOnly = True
            txtObsMer.BackColor = System.Drawing.SystemColors.Control
            ckOtro.Enabled = False
            Me.Text = "Mercadería " + Chr(34) + txtCodMer.Text.ToString + Chr(34)
        Else                    'Nuevo


            btnBuscarMercaderia.Enabled = True
            txtCodMer.ReadOnly = False
            '//////////Mostrar Locacion////////////

            lblUbicacion.Text = oMaestroService.MostrarDato("Maestro.Oficinas", "DesOfi", "CodOfi", oMaestroService.MostrarDato("Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)) & " - " & _
            oMaestroService.MostrarDato("Maestro.Almacenes", "DesAlm", "CodAlm", oMaestroService.MostrarDato("Maestro.Locaciones", "CodAlm", "IdLocacion", IdLocacion))
            '//////////////////////////////////////
            lblUbicacion.BackColor = System.Drawing.SystemColors.Control
            Me.Text = "Registrar nueva Mercadería en locación"
            txtCodMer.Select()
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oMercaderiaService) = False Then
                oMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

   
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                             txtMinMer.KeyUp _
                          , txtMaxMer.KeyUp _
                          , txtUbiMer.KeyUp _
                          , txtObsMer.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Ninguno)"
        Return fila
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodMer.Text) = "" Then
                MsgBox("Debe Ingresar la mercadería", MsgBoxStyle.Information, "Información")
                txtCodMer.BackColor = Color.Red
                txtCodMer.Focus()
                Return False
            ElseIf toNumber(txtMinMer.Value) < 1 Then
                MsgBox("El stock mínimo es 1.", MsgBoxStyle.Information, "Información")
                txtMinMer.BackColor = Color.Red
                txtMinMer.Focus()
                Return False
            ElseIf toNumber(txtMaxMer.Value) < 1 Then
                MsgBox("El stock mínimo es 1.", MsgBoxStyle.Information, "Información")
                txtMaxMer.BackColor = Color.Red
                txtMaxMer.Focus()
                Return False
                'ElseIf toNumber(txtMinMer.Value) > toNumber(txtMaxMer.Value) Then
                '    MsgBox("El valor mínimo no puede ser mayor que el valor máximo.", MsgBoxStyle.Information, "Información")
                '    txtMaxMer.BackColor = Color.Red
                '    txtMaxMer.Focus()
                '    Return False
                'ElseIf toNull(txtUbiMer.Text) = Nothing Then
                '    MsgBox("Debe Ingresar la ubicación de la mercadería", MsgBoxStyle.Information, "Información")
                '    txtUbiMer.BackColor = Color.Red
                '    txtUbiMer.Focus()
                '    Return False
            ElseIf state_button = False And oLocacionMercaderiaService.Buscar(IdLocacion, txtCodMer.Text) Then
                MsgBox("El código de la mercadería " + txtCodMer.Text + " ya existe en el almacén...!", MsgBoxStyle.Information, "Información")
                txtCodMer.Select()
                txtCodMer.Clear()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As LocacionMercaderiaService.LocacionMercaderia)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionMercaderiaService.Insertar(registro)
            type_process = "insert"
            If estado_process = True Then
                Oficina = oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As LocacionMercaderiaService.LocacionMercaderia)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionMercaderiaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Oficina = oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", IdLocacion)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionMercaderiaService.Borrar(toNull(IdLocacion), toNull(txtCodMer.Text))
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub activar()
        'txtUbiMer.ReadOnly = False
        'txtUbiMer.BackColor = System.Drawing.SystemColors.Window
        btnBuscarUbicacion.Enabled = True

        txtMinMer.ReadOnly = False
        txtMinMer.BackColor = System.Drawing.SystemColors.Window
        txtMaxMer.ReadOnly = False
        txtMaxMer.BackColor = System.Drawing.SystemColors.Window
        txtObsMer.ReadOnly = False
        txtObsMer.BackColor = System.Drawing.SystemColors.Window
        ckOtro.Enabled = True

        btnGuardar.Enabled = True
        btnDeshacer.Enabled = True
        btnEditar.Enabled = False

    End Sub
    Private Sub desactivar()
        'txtUbiMer.ReadOnly = True
        'txtUbiMer.BackColor = System.Drawing.SystemColors.Control
        btnBuscarUbicacion.Enabled = False

        txtMinMer.ReadOnly = True
        txtMinMer.BackColor = System.Drawing.SystemColors.Control
        txtMaxMer.ReadOnly = True
        txtMaxMer.BackColor = System.Drawing.SystemColors.Control
        txtObsMer.ReadOnly = True
        txtObsMer.BackColor = System.Drawing.SystemColors.Control
        ckOtro.Enabled = False

        btnEditar.Enabled = True
        btnDeshacer.Enabled = False
        btnGuardar.Enabled = False
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As LocacionMercaderiaService.LocacionMercaderia
            registro = oLocacionMercaderiaService.MostrarPorCodigo(IdLocacion, toBlank(txtCodMer.Text))

            IdLocacion = registro.Locacion.IdLocacion
            lblUbicacion.Text = registro.Locacion.Oficina.DesOfi + " - " + registro.Locacion.Almacen.DesAlm
            txtCodMer.Text = registro.Mercaderia.CodMer

            txtUbiMer.Text = registro.UbiMer
            CodUbicacion = registro.UbiMer

            txtMinMer.Text = registro.MinMer
            txtMaxMer.Text = registro.MaxMer
            lblStock.Text = registro.Stock
            'txtCosDol.Text = registro.CosDol
            'txtCosSol.Text = registro.CosSol
            txtObsMer.Text = registro.ObsMer
            'txtEstado.Text = registro.Estado

            Dim mercaderia As ProductoService.Producto
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            txtDeaMer.Text = mercaderia.DeaMer
            txtCorMer.Text = mercaderia.CorMer
            txtDesMer1.Text = mercaderia.DesMer1
            txtMarca.Text = mercaderia.Marca.DesMar
            txtPais.Text = mercaderia.Pais.DesPais
            txtPartida.Text = mercaderia.Partida.ParPar
            txtObservacion.Text = mercaderia.ObsMer
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesMer1.Text = frm.descripcion
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
            txtCodMer.Text = frm.codigo

            'If toNull(txtCodMer.Text) = Nothing Then
            Dim mercaderia As ProductoService.Producto  'MercaderiaService.Mercaderia
            mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
            txtDeaMer.Text = mercaderia.DeaMer
            txtCorMer.Text = mercaderia.CorMer
            txtDesMer1.Text = mercaderia.DesMer1
            txtMarca.Text = mercaderia.Marca.DesMar
            txtPais.Text = mercaderia.Pais.DesPais
            txtPartida.Text = mercaderia.Partida.ParPar
            txtObservacion.Text = mercaderia.ObsMer
            'End If
        End If
        txtCodMer.Select()
    End Sub
    Private Sub txtMinMer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                      txtMinMer.Click _
                    , txtMaxMer.Click
        If toNumber(txtMinMer.Value) > toNumber(txtMaxMer.Value) Then
            txtMinMer.BackColor = Color.Red
            txtMaxMer.BackColor = Color.Red
        Else
            txtMinMer.BackColor = Color.White
            txtMaxMer.BackColor = Color.White
        End If
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating

        Try
            If Len(Trim(txtCodMer.Text)) > 0 And state_button = False Then
                Dim mercaderia As ProductoService.Producto  'MercaderiaService.Mercaderia
                mercaderia = oMercaderiaService.Obtener(txtCodMer.Text, Session.sCodEmp)
                txtDesMer1.Text = mercaderia.DesMer1
                txtCodMer.BackColor = System.Drawing.SystemColors.Control
                'txtCodMer.Text = mercaderia.Mercaderia.CodMer
                txtDeaMer.Text = mercaderia.DeaMer
                txtCorMer.Text = mercaderia.CorMer
                txtMarca.Text = mercaderia.Marca.DesMar
                txtPais.Text = mercaderia.Pais.DesPais
                txtPartida.Text = mercaderia.Partida.ParPar
                txtObservacion.Text = mercaderia.ObsMer
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Consultar Mercaderia")
        End Try
        
    End Sub

   
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        activar()
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New LocacionMercaderiaService.LocacionMercaderia
            Dim mercaderia As New LocacionMercaderiaService.Mercaderia
            Dim locacion As New LocacionMercaderiaService.Locacion
            Dim empresa As New LocacionMercaderiaService.Empresa

            empresa.CodEmp = Session.sCodEmp
            locacion.Empresa = empresa
            locacion.IdLocacion = toNull(IdLocacion)
            registro.Locacion = locacion
            mercaderia.CodMer = toNull(txtCodMer.Text)
            registro.Mercaderia = mercaderia
            registro.UbiMer = toNull(txtUbiMer.Text)
            registro.MinMer = toNull(txtMinMer.Text)
            registro.MaxMer = toNull(txtMaxMer.Text)
            registro.ObsMer = toNull(txtObsMer.Text)
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
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.MouseEnter
        sslError.Text = "Editar la Detalles de la Mercaderia."
    End Sub

    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.MouseEnter
        sslError.Text = "Grabar los Cambios Hechos en la Mercaderia."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.MouseEnter
        sslError.Text = "Deshacer los Cambios Hechos en Detalles de la mercaderia."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Locacion Mercaderia."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                   btnGuardar.MouseLeave, btnDeshacer.MouseLeave, _
                                   btnEditar.MouseLeave, btnCancelar.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub btnBuscarUbicacion_Click(sender As Object, e As System.EventArgs) Handles btnBuscarUbicacion.Click
        Dim frm As New frmBuscarUbicacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtUbiMer.Text = frm.codigo
            CodUbicacion = frm.codigo
        End If
        txtUbiMer.Focus()
    End Sub

    Private Sub txtUbiMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbiMer.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarUbicacion.Enabled = True Then
                e.Handled = True
                btnBuscarUbicacion_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub ckOtro_CheckedChanged(sender As Object, e As EventArgs) Handles ckOtro.CheckedChanged
        If ckOtro.Checked Then
            txtUbiMer.ReadOnly = False
            txtUbiMer.BackColor = System.Drawing.SystemColors.Window
        Else
            txtUbiMer.ReadOnly = True
            txtUbiMer.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
End Class
