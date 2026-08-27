Imports System.ServiceModel
Public Class frmConsultaDiarioFactura

    '===========================Servicios====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient
    Private oContabilidadDetService As New ContabilidadDetService.ContabilidadDetServiceClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Public IdContabilidad As Integer                ' Id del Registro Diario      
    Private dtMonedas As DataTable
    Private dtTipDocumento As DataTable
    Private dtDatos As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True                   'True: Editable     False: No Editable 

    Private Sub frmDiario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmDiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oContabilidadService.Close()
            oContabilidadDetService.Close()
            oCuentaContableService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oContabilidadService.Abort()
            oContabilidadDetService.Abort()
            oCuentaContableService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        'oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 175)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()
        Desactivar()
        ObtenerRegistro()
        listaDatos()
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdContabilidadDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdContabilidadDet").Text
                End If
            End If
            dtDatos = Nothing
            ObtenerRegistro()
            listaDatos()            
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        txtPeriodo.ReadOnly = True
        txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        cmbTipoLibro.ReadOnly = True
        cmbTipoLibro.BackColor = System.Drawing.SystemColors.Window
        txtMesRegistro.ReadOnly = True
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
        txtNumRegistro.ReadOnly = True
        txtNumRegistro.BackColor = System.Drawing.SystemColors.Window



        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtTipCambio.ReadOnly = True
        txtTipCambio.BackColor = System.Drawing.SystemColors.Control

        txtNombre.ReadOnly = True
        txtNombre.BackColor = System.Drawing.SystemColors.Control
        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control

        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        'rbAnulado.Enabled = False

        edicion = False
        enableOpciones()
    End Sub


    Private Sub enableOpciones()

        biSalir.Enabled = Not edicion
        biImprimir.Enabled = IIf(Not edicion, True, False)


    End Sub



    Private Sub ObtenerRegistro()
        Try
            Dim registro As New ContabilidadService.Contabilidad
            registro = oContabilidadService.Obtener(IdContabilidad)

            IdContabilidad = registro.IdContabilidad
            txtPeriodo.Value = registro.Periodo
            cmbTipoLibro.Value = registro.TipoLibro.IdLibro
            txtMesRegistro.Text = registro.Mes
            txtNumRegistro.Text = registro.NumRegistro

            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtTipCambio.Value = registro.TipCam

            txtNombre.Text = registro.Nombre
            txtGlosa.Text = registro.Glosa

            cmbMoneda.Value = registro.Moneda.CodMon
            rbAnulado.Checked = registro.Anulado

            txtTotalDebeSol.Value = registro.TotalDebeSol
            txtTotalHaberSol.Value = registro.TotalHaberSol

            txtTotalDebeDol.Value = registro.TotalDebeDol
            txtTotalHaberDol.Value = registro.TotalHaberDol
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos1(ByVal data As DataTable)
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
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            '===================================TIPO DE LIBRO ===========================================
            dtTipDocumento = oContabilidadService.MostrarTipoLibros.Tables(0)
            'dtTipDocumento.Rows.InsertAt(getRowTodos1(dtMonedas), 0)            
            cmbTipoLibro.DataSource = dtTipDocumento
            cmbTipoLibro.DropDownList.DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.DisplayMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.ValueMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(0).DataMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoLibro.DropDownList.Columns(1).DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoLibro.DropDownList.Columns(2).DataMember = dtTipDocumento.Columns("DesLibro").ToString
            cmbTipoLibro.SelectedIndex = 0
            dtTipDocumento = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.SelectedIndex = 0
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub




    Private Sub listaDatos()
        Try
            dtDatos = oContabilidadDetService.Mostrar(toNumber(IdContabilidad)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()

            If dgvDatos.RowCount > 0 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
                'InhabilitarColumnas()
            Else
                txtDesCuenta.Text = ""
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub


    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If IdContabilidad = 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function



    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        actualizarDetalles()
    End Sub


    Private Sub dgvDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.CurrentCellChanged
        If dgvDatos.RowCount > 0 Then
            If dgvDatos.Col = 11 Then
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("Nombre").Text)
            Else
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
            End If
        Else
            txtDesCuenta.Text = ""
        End If
    End Sub


    'Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If dgvDatos.RowCount > 0 Then
    '            miMostrar_Click(sender, e)
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Function ValidaCodigoSeleccionadoDet() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        'If dgvDatos.RowCount > 0 Then
        '    txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
        'Else
        '    txtDesCuenta.Text = ""
        'End If
    End Sub

    Private Sub txtTotalDebeNS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeSol.ValueChanged, txtTotalHaberSol.ValueChanged
        txtDiferenciaSol.Value = txtTotalDebeSol.Value - txtTotalHaberSol.Value
    End Sub

    Private Sub txtTotalDebeUS_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalDebeDol.ValueChanged, txtTotalHaberDol.ValueChanged
        txtDiferenciaDol.Value = txtTotalDebeDol.Value - txtTotalHaberDol.Value
    End Sub






    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbTipoLibro.Focus()
        End If
    End Sub



    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptDiario

            If IdContabilidad <> 0 Then
                dtReporte = oContabilidadService.Imprimir(IdContabilidad).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.DisplayGroupTree = False
                    'reporte.SetParameterValue("pIdMesa", 0)
                    forma.Text = "Reporte de Diario"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Registro Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub dgvDatos_FormattingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvDatos.FormattingRow

    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Close()

    End Sub
End Class