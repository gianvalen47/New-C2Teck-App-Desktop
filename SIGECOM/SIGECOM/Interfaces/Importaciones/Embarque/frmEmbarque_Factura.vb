Imports Janus.Windows.GridEX
Imports System.ServiceModel
Public Class frmEmbarque_Factura

    '===========================Servicios====================================================
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oEmbarqueDetService As New EmbarqueDetService.EmbarqueDetServiceClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public CodEmbarque As String
    Private IdFactura As Integer
    Public Medio As String

    Private Sub frmEmbarque_Factura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        ListaDatos()
    End Sub

    Private Sub frmEmbarque_Factura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_IngMas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaImportService.Close()
            oEmbarqueDetService.Close()
        Catch ex As TimeoutException
            oFacturaImportService.Abort()
            oEmbarqueDetService.Abort()
        Catch ex As CommunicationException
            oFacturaImportService.Abort()
            oEmbarqueDetService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oFacturaImportService.MostrarPendientes(Session.sCodEmp, Medio).Tables(0)
            dgvDatos.DataSource = dtDatos            
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            'If toNull(txtFecDoc.Text) = Nothing Then
            '    MsgBox("Debe Ingresar la fecha de la factura", MsgBoxStyle.Information, "Información")
            '    txtFecDoc.Focus()
            '    Return False
            'ElseIf toBlank(cmbOficinas.Value) = "" Then
            '    MsgBox("Debe Ingresar la Oficina", MsgBoxStyle.Information, "Información")
            '    cmbOficinas.Focus()
            '    Return False
            'ElseIf toBlank(cmbIdLocacion.Value) = "" Then
            '    MsgBox("Debe Ingresar la Almacen", MsgBoxStyle.Information, "Información")
            '    cmbIdLocacion.Focus()
            '    Return False
            'Else
            Return True
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim Ingresado As Integer = 0
                    Dim rows() As Janus.Windows.GridEX.GridEXRow

                    rows = dgvDatos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    If rows.Count <> 0 Then
                        For Each row In rows
                            Dim estado_process As Integer


                            Dim registro As New EmbarqueDetService.EmbarqueDet
                            Dim Embarque As New EmbarqueDetService.Embarque
                            Dim Factura As New EmbarqueDetService.FacturaImport

                            Embarque.CodEmbarque = CodEmbarque
                            registro.Embarque = Embarque
                            Factura.IdFactura = toNumber(row.Cells("IdFactura").Text)
                            registro.FacturaImport = Factura

                            registro.NroPaquete = toNull(row.Cells("NroPaquete").Text)
                            registro.Observacion = toNull("")

                            registro.CodUsu = Session.sCodUsu
                            registro.DirIp = Session.sDirIp
                            registro.NomPc = Session.sNomPc
                            registro.FecReg = Today

                            estado_process = oEmbarqueDetService.Insertar(registro)

                            If estado_process = True Then
                                Ingresado = Ingresado + 1
                            End If
                        Next

                        If Ingresado > 0 Then
                            MsgBox("Facturas de Importación ingresadas correctamente")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    Else
                        MsgBox("Debe seleccionar alguna de las facturas de importación")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class
