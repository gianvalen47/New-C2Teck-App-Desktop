Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Net
Imports ConsultasSunat
Imports ConsultasSunat.EntidadNegocio
Imports System.Net.Http
Imports Newtonsoft.Json
Imports UblLarsen.Ubl21.Aplicacion
Imports FacturarSunat21.aplicacion

Public Class frmTipoCambio
    Private dtMonedas As New DataTable
    ' Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjSeguridad As New SeguridadService.SeguridadClient

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("¿Está Seguro de INGRESAR Tipo de Cambio?", MsgBoxStyle.YesNo, "Ingresar") = MsgBoxResult.Yes Then
            If txtTipCamVenta.Value = 0 Or txtTipCamCompra.Value = 0 Then
                MsgBox("Error de Datos: ", MsgBoxStyle.Critical)
            Else
                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                Try
                    ObjSeguridad.InsertarTipoCambio(cbCodMon.Value, Session.sFecha, txtTipCamVenta.Value, txtTipCamCompra.Value, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString())
                    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Finalizar()
                    MDIPrincipal.Show()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Datos")
                End Try
            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Finalizar()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Cancel_Button_Click(sender, e)
        End If
    End Sub

    Private Sub frmTipoCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtMonedas = ObjSeguridad.MostrarMonedasParaTipoCambio.Tables(0)
        cbCodMon.DataSource = dtMonedas
        cbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
        cbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
        cbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
        cbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
        cbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
        dtMonedas = Nothing
        cbCodMon.Value = "US"
        cbFecha.Value = Session.sFecha
        'cbFecha.ReadOnly = True

        txtTipCamVenta.Focus()
        'cbCodMon.ReadOnly = True
    End Sub

    Private Sub Finalizar()
        Try
            ObjSeguridad.Close()
            'ObjMaestro.Close()
        Catch ex As TimeoutException
            ObjSeguridad.Abort()
            'ObjMaestro.Abort()
        Catch ex As CommunicationException
            ObjSeguridad.Abort()
            'ObjMaestro.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub txtTipCamVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipCamVenta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            OK_Button_Click(sender, e)
        End If
    End Sub

    Private Sub txtTipCamCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipCamCompra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtTipCamVenta.Focus()
        End If
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
        Dim sDia As String = Session.sFecha.Day.ToString
        Dim sMes As String = Session.sFecha.Month.ToString
        Dim sAnio As String = Session.sFecha.Year.ToString

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

                                    txtTipCamCompra.Text = oEnTipoCambioDia.Compra
                                    txtTipCamVenta.Text = oEnTipoCambioDia.Venta

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

    Private Sub btnConsultarSunat_Click(sender As Object, e As EventArgs) Handles btnConsultarSunat.Click
        'ObtenerTipoCambioExterno()

        Try
            Dim tipoCambio As New TipoCambioSunat()

            Dim fecha As String = Session.sFecha.ToString("yyyy-MM-dd")

            tipoCambio = ConectarAPISUNAT.ConsultarTipoCambioSunat(fecha)

            txtTipCamCompra.Value = tipoCambio.Compra
            txtTipCamVenta.Value = tipoCambio.Venta

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Consulta")
        End Try

    End Sub

    Private Sub lblMensaje_Click(sender As Object, e As EventArgs) Handles lblMensaje.Click

    End Sub
End Class
