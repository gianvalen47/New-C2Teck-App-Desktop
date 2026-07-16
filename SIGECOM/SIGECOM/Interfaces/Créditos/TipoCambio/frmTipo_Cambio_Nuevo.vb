Imports System.Net
Imports System.Net.Http
Imports System.ServiceModel
Imports ConsultasSunat
Imports ConsultasSunat.EntidadNegocio
Imports FacturarSunat21.aplicacion
Imports Newtonsoft.Json
Imports UblLarsen.Ubl21.Aplicacion

Public Class frmTipo_Cambio_Nuevo

    '=========================== Servicios ====================================
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestroService As New MaestroService.MaestroClient

    '====================== Declaración de Variables ==============================
    Public state_button As Boolean           'True: Modificar    False: nuevo
    Public type_process As String             'update     insert      delete
    Public moneda As String
    Public fecha As Date
    Private dtMonedas As DataTable

    Private Sub frmTipo_Cambio_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmTipo_Cambio_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 307)
        '/*************************************************************************************/

        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtVenta.Focus()
            Me.Text = "Tipo de Cambio Fecha: " + fecha.Day.ToString + "/" + fecha.Month.ToString + "/" + fecha.Year.ToString
        Else                                      'Nuevo       
            activar()
            txtFecha.Value = Today
            txtFecha.Focus()
            cmbMoneda.Value = "US"
            Me.Text = "Nuevo Tipo de Cambio"
        End If
        EnableOptions()
    End Sub

    Private Sub frmTipo_Cambio_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe de Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toDouble(txtVenta.Value) = 0 Then
                MsgBox("Debe ingresar Tipo de Cambio Venta.", MsgBoxStyle.Information, "Información")
                txtVenta.Focus()
                Return False
            ElseIf toDouble(txtCompra.Value) = 0 Then
                MsgBox("Debe ingresar Tipo de Cambio Compra.", MsgBoxStyle.Information, "Información")
                txtVenta.Focus()
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
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        txtVenta.ReadOnly = False
        txtVenta.BackColor = System.Drawing.SystemColors.Window
        txtCompra.ReadOnly = False
        txtCompra.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtVenta.ReadOnly = False
        txtVenta.BackColor = System.Drawing.SystemColors.Window
        txtCompra.ReadOnly = False
        txtCompra.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub Insertar()
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.InsertarTipoCambio(cmbMoneda.Value, txtFecha.Value, txtVenta.Value, txtCompra.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "insert"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar()
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.ActualizarTipoCambio(cmbMoneda.Value, txtFecha.Value, txtVenta.Value, txtCompra.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            txtFecha.Value = fecha
            cmbMoneda.Value = moneda
            txtVenta.Value = oSeguridadService.MostrarTipoCambio(moneda, fecha)
            txtCompra.Value = oSeguridadService.MostrarTipoCambioCompra(moneda, fecha)

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= MONEDAS ==============================================
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                If state_button Then        'Modificar
                    Modificar()
                Else                              'Nuevo                    
                    Insertar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR TIPO DE CAMBIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=================================== Evento KeyPress =========================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtFecha.KeyPress _
                           , cmbMoneda.KeyPress _
                           , txtVenta.KeyPress _
                           , txtCompra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnConsultarSunat_Click(sender As Object, e As EventArgs) Handles btnConsultarSunat.Click
        'ObtenerTipoCambioExterno()

        Try
            Dim tipoCambio As New TipoCambioSunat()

            Dim fecha As String = txtFecha.Value.ToString("yyyy-MM-dd")

            tipoCambio = ConectarAPISUNAT.ConsultarTipoCambioSunat(fecha)

            txtCompra.Value = tipoCambio.Compra
            txtVenta.Value = tipoCambio.Venta

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Consulta")
        End Try





    End Sub

    Private Async Sub ObtenerTipoCambioExterno()
        Dim tipoRespuesta = 2
        Dim mensajeRespuesta = ""
        Dim lEnTipoCambio As List(Of EnTipoCambio) = New List(Of EnTipoCambio)()
        Dim oEnTipoCambio As EnTipoCambio
        lblMensaje.Text = ""
        btnConsultarSunat.Enabled = False
        Dim oCronometro As Stopwatch = New Stopwatch()
        oCronometro.Start()
        txtVenta.Text = 0.00
        txtCompra.Text = 0.00
        Dim sDia As String = txtFecha.Value.Day.ToString
        Dim sMes As String = txtFecha.Value.Month.ToString
        Dim sAnio As String = txtFecha.Value.Year.ToString

        Dim ObjCon As New ConsultaTipoCambio

        Try
            Dim resultadoUrlServicio As String = ObjCon.ObtenerUrlServicio(sDia, sMes, sAnio)
            Dim arrResultadoUrlServicio = resultadoUrlServicio.Split("~"c)

            If Equals(arrResultadoUrlServicio(0), "1") Then
                Using cliente As HttpClient = New HttpClient()
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12

                    Using resultadoConsulta As HttpResponseMessage = Await cliente.GetAsync(New Uri(arrResultadoUrlServicio(1)))

                        If resultadoConsulta.IsSuccessStatusCode Then
                            Dim contenidoResultado As String = Await resultadoConsulta.Content.ReadAsStringAsync()

                            If Equals(contenidoResultado.Trim(), "") Then
                                mensajeRespuesta = "Se realizó correctamente la consulta a la URL de SUNAT pero no devolvió el valor en el contenido."
                            Else

                                If contenidoResultado.IndexOf("error") > -1 Then
                                    Dim urlServicio = arrResultadoUrlServicio(1)
                                    Dim ultimoIndice = urlServicio.LastIndexOf("/"c)
                                    mensajeRespuesta = If(ultimoIndice > -1, String.Format("No existe la información solicitada {0}", urlServicio.Substring(ultimoIndice + 1, urlServicio.Length - ultimoIndice - 1)), String.Format("No existe la información solicitada con la URL {0}", urlServicio))
                                Else
                                    Dim lObjetoResultado As Dictionary(Of String, EnTipoCambioDia) = JsonConvert.DeserializeObject(Of Dictionary(Of String, EnTipoCambioDia))(contenidoResultado)
                                    Dim oEnTipoCambioDia As EnTipoCambioDia

                                    For Each objetoResultado In lObjetoResultado
                                        oEnTipoCambio = New EnTipoCambio()
                                        oEnTipoCambioDia = objetoResultado.Value
                                        oEnTipoCambio.Fecha = objetoResultado.Key
                                        oEnTipoCambio.Compra = oEnTipoCambioDia.Compra
                                        oEnTipoCambio.Venta = oEnTipoCambioDia.Venta
                                        lEnTipoCambio.Add(oEnTipoCambio)
                                    Next

                                    txtCompra.Text = oEnTipoCambioDia.Compra
                                    txtVenta.Text = oEnTipoCambioDia.Venta

                                    tipoRespuesta = 1
                                End If
                            End If
                        Else
                            mensajeRespuesta = Await resultadoConsulta.Content.ReadAsStringAsync()
                            mensajeRespuesta = String.Format("Ocurrió un inconveniente al consultar el tipo de cambio desde la URL de SUNAT." & vbCrLf & "Detalle: {0}", mensajeRespuesta)
                        End If
                    End Using
                End Using
            Else
                tipoRespuesta = Convert.ToInt16(arrResultadoUrlServicio(0))
                mensajeRespuesta = arrResultadoUrlServicio(1)
            End If

        Catch ex As Exception
            tipoRespuesta = 3
            mensajeRespuesta = ex.Message
            If ex.InnerException IsNot Nothing Then mensajeRespuesta = String.Format("{0}" & vbCrLf & vbCrLf & "{1}", mensajeRespuesta, ex.InnerException.Message)
        End Try

        'Establecer los valores del objeto de la clase EnTipoCambio a los controles del formulario 
        'Dim tabla As DataTable = CType(dgvTipoCambio.DataSource, DataTable).Clone()
        Dim nTipoCambio = lEnTipoCambio.Count

        'If nTipoCambio > 0 Then
        '    Dim filaTabla As DataRow

        '    For i = 0 To nTipoCambio - 1
        '        filaTabla = tabla.NewRow()
        '        oEnTipoCambio = lEnTipoCambio(i)
        '        filaTabla(0) = oEnTipoCambio.Fecha
        '        filaTabla(1) = oEnTipoCambio.Compra
        '        filaTabla(2) = oEnTipoCambio.Venta
        '        tabla.Rows.Add(filaTabla)
        '    Next
        'End If
        'dgvTipoCambio.DataSource = tabla
        ''///////////////////////


        oCronometro.[Stop]()
        If tipoRespuesta > 1 Then MessageBox.Show(mensajeRespuesta, "Consultar Tipo de Cambio", MessageBoxButtons.OK, If(tipoRespuesta = 2, MessageBoxIcon.Warning, MessageBoxIcon.[Error]))
        lblMensaje.Text = String.Format("Se encontró {0} resultado{1} ({2} segundos)", nTipoCambio, If(nTipoCambio = 1, "", "s"), Math.Round(oCronometro.Elapsed.TotalSeconds, 2))
        btnConsultarSunat.Enabled = True

    End Sub

End Class