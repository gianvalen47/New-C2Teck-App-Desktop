Imports System.ServiceModel

Public Class frmHorasMotor_IngresoMasivo

    '=========================== Servicios ====================================
    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient

    Public CodUbicacion As String
    Public DesUbicacion As String
    Public TipoMantenimiento As String
    Public TipoEquipo As String
    Public Activo As Boolean

    Private dtDatos As DataTable
    Private dtDatosTemp As DataTable
    Private dtUbicacion As DataTable
    Private dtTipoPlanMantenimiento As DataTable
    Private dtTipoEquipo As DataTable
    Private dtInsertarMasivo As DataTable

    Private Sub frmHorasMotor_IngresoMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorasMotorService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
        Catch ex As CommunicationException
            oHorasMotorService.Abort()
        End Try
    End Sub

    Private Sub frmHorasMotor_IngresoMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHorasMotor_IngresoMasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With dgvDatos
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.AliceBlue
            .BackgroundColor = Color.Beige

            .BackColor = Color.Beige
            .ForeColor = Color.MidnightBlue
            .BorderStyle = BorderStyle.None
            .Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Bold)
        End With
        ListaDatos()
        txtUbicacion.Text = DesUbicacion

    End Sub

    Private Sub ListaDatos()

        dtDatos = oHorasMotorService.Filtrar("", "", toBlank(CodUbicacion), toNumber(TipoMantenimiento), toNumber(TipoEquipo), Activo).Tables(0)
        dgvDatosTemp.DataSource = dtDatos

        'dtDatos = oHorasMotorService.Filtrar("", "", toBlank(CodUbicacion), toNumber(TipoMantenimiento), toNumber(TipoEquipo)).Tables(0)
        'dgvDatos.DataSource = dtDatos

        cNumSerie.DataPropertyName = dtDatos.Columns("NumSerie").ColumnName
        cNomEquipo.DataPropertyName = dtDatos.Columns("NomEquipo").ColumnName
        cTotalHoras.DataPropertyName = dtDatos.Columns("TotalHoras").ColumnName
        cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName

        CreacionTableInicial()

    End Sub

    Private Sub CreacionTableInicial()

        Try
            Dim row2 As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("NumSerie", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomEquipo", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TotalHoras", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("HoraTotalNueva", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"", "", "0.00", "0.00", ""})

            dtDatosTemp = dtCopia.Copy
            dtDatosTemp.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatosTemp.Rows(i)

                row2 = dtDatosTemp.NewRow

                row2(0) = Trim(row.Cells("cNumSerie").Value)
                row2(1) = Trim(row.Cells("cNomEquipo").Value)
                row2(2) = CDbl(row.Cells("cTotalHoras").Value)
                row2(3) = "0.00"
                row2(4) = Trim(IIf(IsDBNull(row.Cells("cObservacion").Value), "", row.Cells("cObservacion").Value))

                dtDatosTemp.Rows.Add(row2)

            Next

            dgvDatos.DataSource = dtDatosTemp

            cNumSerie2.DataPropertyName = dtDatosTemp.Columns("NumSerie").ColumnName
            cNomEquipo2.DataPropertyName = dtDatosTemp.Columns("NomEquipo").ColumnName
            cTotalHoras2.DataPropertyName = dtDatosTemp.Columns("TotalHoras").ColumnName
            cObservacion2.DataPropertyName = dtDatosTemp.Columns("Observacion").ColumnName

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresar.Click

        If ComprobarIngresoHoras() Then
            If MsgBox("¿Está seguro de INGRESAR las horas?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                txtUbicacion.Focus()
                CreacionDataTable()
            End If
        End If

    End Sub

    Private Function ComprobarIngresoHoras() As Boolean
        Try
            Dim x As Double = 0.0

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatos.Rows(i)

                x = x + CDbl(row.Cells("cHoraTotalNueva2").Value)

            Next

            If x = 0.0 Then
                MsgBox("Ingrese las horas a registrar, tenga cuidado. ", MsgBoxStyle.Information, "Información")
                dgvDatos.Focus()
                Return False

            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function


    Private Sub CreacionDataTable()

        Try
            Dim row2 As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("NumSerie", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("TotalHoras", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))

            dtCopia.Rows.Add(New Object() {"", "0.00", ""})

            dtInsertarMasivo = dtCopia.Copy
            dtInsertarMasivo.Clear()


            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatos.Rows(i)

                row2 = dtInsertarMasivo.NewRow

                row2(0) = Trim(row.Cells("cNumSerie2").Value)
                row2(1) = CDbl(row.Cells("cHoraTotalNueva2").Value)
                row2(2) = Trim(IIf(IsDBNull(row.Cells("cObservacion2").Value), "", row.Cells("cObservacion2").Value))

                dtInsertarMasivo.Rows.Add(row2)

            Next

            If dtInsertarMasivo.Rows.Count = dgvDatos.RowCount Then
                InsertarMasivo()
            End If

        Catch ex As Exception
            MsgBox("Error al Crear el Datatable InsertarMasivo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub InsertarMasivo()

        Try
            Dim estado_process As Boolean

            estado_process = oHorasMotorService.ActualizarHorasMasivas(dtInsertarMasivo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process = True Then
                MsgBox("Se Actualizaron las horas correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LAS HORAS MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

End Class