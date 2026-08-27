Imports System.ServiceModel
Public Class frmFactura_Cuotas

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oDocCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private dtDatos As DataTable

    Public IdFactura As Int32
    Public FecDoc As Date
    Public TotNeto As Double
    Public CodPag As String

    Private Sub frmFactura_Cuotas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmFactura_Cuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_Cuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaService.Close()
            oDocCtaCte.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oDocCtaCte.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oDocCtaCte.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oFacturaService.MostrarCuota(IdFactura).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()

        Try
            Dim frm As New frmFactura_Cuotas_Nuevo
            frm.state_button = False
            frm.IdFactura = IdFactura
            'frm.btnEditar.Enabled = False
            'frm.btnCancelar.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, frm.CodEmp)
                    'mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click

        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmFactura_Cuotas_Nuevo
            frm.state_button = True
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.NumeroCuota = dgvDatos.CurrentRow.Cells("NumeroCuota").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then

                    listaDatos()
                    RowPossesion(dgvDatos, frm.NumeroCuota)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("NumeroCuota").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("NumeroCuota").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
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

    Private Sub eliminar()

        Try
            If MsgBox("¿Está seguro de ELIMINAR la Cuota seleccionada?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oFacturaService.BorrarCuota(CInt(dgvDatos.CurrentRow.Cells("IdFactura").Text), CInt(dgvDatos.CurrentRow.Cells("NumeroCuota").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA CUOTA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biCuotaUnica_Click(sender As Object, e As EventArgs) Handles biCuotaUnica.Click, miCuotaUnica.Click

        Try

            Dim registro As New FacturaService.FacturaCuotas
            Dim empresa As New FacturaService.Empresa
            Dim factura As New FacturaService.Factura
            Dim fecVencimiento As Date = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)

            registro.NumeroCuota = 1
            registro.MontoCuota = TotNeto
            registro.FecVencimiento = fecVencimiento

            factura.IdFactura = IdFactura
            registro.Factura = factura

            registro.FecReg = Date.Today

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim estado_process As Boolean
            estado_process = oFacturaService.InsertarCuota(registro)

            If estado_process Then
                listaDatos()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CUOTA UNICA : " + ex.Message)
        End Try

    End Sub
End Class