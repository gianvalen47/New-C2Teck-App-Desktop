Imports System.ServiceModel
Public Class frmUbicacion

    '=========================== Servicios ====================================
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public CodUbicacion As String                  'Código de Ubicación seleccionado

    Private dtEstante As DataTable
    Private dtNivel As DataTable
    Private dtCelda As DataTable
    Private dtLado As DataTable

    Private Sub frmUbicacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Finalizar()
    End Sub

    Private Sub frmUbicacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtCodUbicacion.TabStop = False
            cmbEstante.Focus()
        Else                                      'Nuevo            
            activar()
            txtCodUbicacion.TabStop = True
            txtCodUbicacion.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub frmUbicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oLocacionMercaderiaService.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try           
            If toBlank(cmbEstante.Value) = "" Then
                MsgBox("Debe ingresar el Estante de la ubicación de mercadería", MsgBoxStyle.Information, "Información")
                cmbEstante.Focus()
                Return False
            ElseIf toBlank(cmbNivel.Value) = "" Then
                MsgBox("Debe ingresar el Nivel de la ubicación de mercadería", MsgBoxStyle.Information, "Información")
                cmbNivel.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtCodUbicacion.ReadOnly = True
        txtCodUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbEstante.ReadOnly = False
        cmbEstante.BackColor = System.Drawing.SystemColors.Window
        cmbNivel.ReadOnly = False
        cmbNivel.BackColor = System.Drawing.SystemColors.Window
        cmbCelda.ReadOnly = False
        cmbCelda.BackColor = System.Drawing.SystemColors.Window
        cmbLado.ReadOnly = False
        cmbLado.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtCodUbicacion.ReadOnly = True
        txtCodUbicacion.BackColor = System.Drawing.SystemColors.Control
        cmbEstante.ReadOnly = True
        cmbEstante.BackColor = System.Drawing.SystemColors.Control
        cmbNivel.ReadOnly = True
        cmbNivel.BackColor = System.Drawing.SystemColors.Control
        cmbCelda.ReadOnly = True
        cmbCelda.BackColor = System.Drawing.SystemColors.Control
        cmbLado.ReadOnly = True
        cmbLado.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar(ByVal registro As LocacionMercaderiaService.Ubicacion)
        Try
            Dim estado_process As String
            estado_process = oLocacionMercaderiaService.InsertarUbicacion(registro)
            type_process = "insert"
            If estado_process = True Then
                CodUbicacion = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LocacionMercaderiaService.Ubicacion)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionMercaderiaService.ActualizarUbicacion(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LocacionMercaderiaService.Ubicacion
            registro = oLocacionMercaderiaService.ObtenerUbicacion(CodUbicacion, Session.sCodEmp)

            CodUbicacion = registro.CodUbicacion
            txtCodUbicacion.Text = registro.CodUbicacion
            cmbEstante.Value = registro.Estante.CodEstante
            cmbNivel.Value = registro.CodNivel
            cmbCelda.Value = registro.CodCelda
            cmbLado.Value = registro.CodLado
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub llenarCombos()
        Try

            '======================================= ESTANTE =============================================
            dtEstante = oLocacionMercaderiaService.MostrarEstante().Tables(0)
            'dtEstante.Rows.InsertAt(getRowTodos(dtEstante), 0)
            cmbEstante.DataSource = dtEstante
            cmbEstante.DropDownList.DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.DisplayMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.DropDownList.ValueMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(0).DataMember = dtEstante.Columns("CodEstante").ToString
            cmbEstante.DropDownList.Columns(1).DataMember = dtEstante.Columns("DesEstante").ToString
            cmbEstante.SelectedIndex = 0
            dtEstante = Nothing


            '========================================= NIVEL =============================================
            dtNivel = New DataTable
            dtNivel.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtNivel.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))            
            dtNivel.Rows.Add(New Object() {"A", "A"})
            dtNivel.Rows.Add(New Object() {"B", "B"})
            dtNivel.Rows.Add(New Object() {"C", "C"})
            dtNivel.Rows.Add(New Object() {"D", "D"})
            dtNivel.Rows.Add(New Object() {"E", "E"})
            dtNivel.Rows.Add(New Object() {"F", "F"})
            dtNivel.Rows.Add(New Object() {"G", "G"})
            dtNivel.Rows.Add(New Object() {"H", "H"})
            dtNivel.Rows.Add(New Object() {"M", "M"})
            dtNivel.Rows.Add(New Object() {"P", "P"})
            dtNivel.Rows.Add(New Object() {"S", "S"})
            dtNivel.Rows.Add(New Object() {"T", "T"})

            cmbNivel.DataSource = dtNivel
            cmbNivel.DropDownList.DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.DisplayMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.ValueMember = dtNivel.Columns("nombre").ToString
            cmbNivel.DropDownList.Columns(0).DataMember = dtNivel.Columns("codigo").ToString
            cmbNivel.DropDownList.Columns(1).DataMember = dtNivel.Columns("nombre").ToString
            cmbNivel.SelectedIndex = 0
            dtNivel = Nothing


            '========================================= CELDA =============================================
            dtCelda = New DataTable
            dtCelda.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtCelda.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtCelda.Rows.Add(New Object() {"", "Ninguno"}) ', New DateTime(2008, 2, 5)
            dtCelda.Rows.Add(New Object() {"1", "1"}) 
            dtCelda.Rows.Add(New Object() {"2", "2"})
            dtCelda.Rows.Add(New Object() {"3", "3"})
            dtCelda.Rows.Add(New Object() {"4", "4"})
            dtCelda.Rows.Add(New Object() {"5", "5"})
            dtCelda.Rows.Add(New Object() {"6", "6"})
            dtCelda.Rows.Add(New Object() {"7", "7"})
            dtCelda.Rows.Add(New Object() {"8", "8"})
            dtCelda.Rows.Add(New Object() {"9", "9"})
            dtCelda.Rows.Add(New Object() {"10", "10"})
            dtCelda.Rows.Add(New Object() {"11", "11"})
            dtCelda.Rows.Add(New Object() {"12", "12"})
            dtCelda.Rows.Add(New Object() {"13", "13"})
            dtCelda.Rows.Add(New Object() {"14", "14"})
            dtCelda.Rows.Add(New Object() {"15", "15"})
            dtCelda.Rows.Add(New Object() {"16", "16"})
            dtCelda.Rows.Add(New Object() {"17", "17"})
            dtCelda.Rows.Add(New Object() {"18", "18"})
            dtCelda.Rows.Add(New Object() {"21", "21"})
            dtCelda.Rows.Add(New Object() {"22", "22"})
            dtCelda.Rows.Add(New Object() {"23", "23"})
            dtCelda.Rows.Add(New Object() {"24", "24"})
            dtCelda.Rows.Add(New Object() {"25", "25"})
            dtCelda.Rows.Add(New Object() {"26", "26"})
            dtCelda.Rows.Add(New Object() {"27", "27"})
            dtCelda.Rows.Add(New Object() {"29", "29"})
            dtCelda.Rows.Add(New Object() {"30", "30"})
            dtCelda.Rows.Add(New Object() {"31", "31"})

            cmbCelda.DataSource = dtCelda
            cmbCelda.DropDownList.DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.DisplayMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.ValueMember = dtCelda.Columns("nombre").ToString
            cmbCelda.DropDownList.Columns(0).DataMember = dtCelda.Columns("codigo").ToString
            cmbCelda.DropDownList.Columns(1).DataMember = dtCelda.Columns("nombre").ToString
            cmbCelda.SelectedIndex = 0
            dtCelda = Nothing


            '========================================= LADO =============================================
            dtLado = New DataTable
            dtLado.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtLado.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtLado.Rows.Add(New Object() {"", "Ninguno"}) ', New DateTime(2008, 2, 5)
            dtLado.Rows.Add(New Object() {"A", "A"})
            dtLado.Rows.Add(New Object() {"B", "B"})

            cmbLado.DataSource = dtLado
            cmbLado.DropDownList.DataMember = dtLado.Columns("nombre").ToString
            cmbLado.DropDownList.DisplayMember = dtLado.Columns("nombre").ToString
            cmbLado.DropDownList.ValueMember = dtLado.Columns("nombre").ToString
            cmbLado.DropDownList.Columns(0).DataMember = dtLado.Columns("codigo").ToString
            cmbLado.DropDownList.Columns(1).DataMember = dtLado.Columns("nombre").ToString
            cmbLado.SelectedIndex = 0
            dtLado = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LocacionMercaderiaService.Ubicacion
                Dim estante As New LocacionMercaderiaService.Estante
                Dim empresa As New LocacionMercaderiaService.Empresa

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.CodUbicacion = txtCodUbicacion.Text
                estante.CodEstante = cmbEstante.Value
                registro.Estante = estante
                registro.CodNivel = cmbNivel.Value
                registro.CodLado = IIf(cmbLado.SelectedIndex = 0, Nothing, cmbLado.Value)
                registro.CodCelda = IIf(cmbCelda.SelectedIndex = 0, Nothing, cmbCelda.Value)
                registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR UBICACIÓN DE MERCADERÍA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtCodUbicacion.KeyPress _
                           , cmbEstante.KeyPress _
                           , cmbNivel.KeyPress _
                           , cmbCelda.KeyPress _
                           , cmbLado.KeyPress _
                           , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
