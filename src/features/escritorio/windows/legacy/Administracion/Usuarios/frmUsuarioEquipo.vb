Imports System.ServiceModel
Imports System.Management


Public Class frmUsuarioEquipo

    '===========================Servicios====================================
    Private oSeguridadService As New SeguridadService.SeguridadClient


    '======================Declaración de Variables==============================   
    Public CodUsu As String
    Public serialBoard As String = ""
    Private ArquitecturaSO As String = ""


    Private Sub frmUsuarioRubroRecurso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()

        Catch ex As TimeoutException
            oSeguridadService.Abort()

        Catch ex As CommunicationException
            oSeguridadService.Abort()

        End Try
    End Sub

    Private Sub frmUsuarioRubroRecurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioRubroRecurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenarCombos()
        'cmbRubro.Focus()
        Informacion()
    End Sub

    Sub Informacion()
        ':::Obtenemos la informacion del Sistema operativo
        LblNombreSO.Text = "Nombre del SO: " + My.Computer.Info.OSFullName
        LblVersionSO.Text = "Versión del SO: " + My.Computer.Info.OSVersion

        Dim consultaSQLArquitectura As String = "SELECT * FROM Win32_Processor"
        Dim objArquitectura As New ManagementObjectSearcher(consultaSQLArquitectura)

        For Each info As ManagementObject In objArquitectura.Get()
            ArquitecturaSO = info.Properties("AddressWidth").Value.ToString()
        Next info
        LblArquitecturaSO.Text = "Arquitectura del SO: " + ArquitecturaSO + " Bits"

        ':::Obtenemos la informacion del Equipo
        LblNombreEquipo.Text = "Nombrel del Equipo: " + My.Computer.Name
        LblNombreUsuario.Text = "Nombre del Usuario: " + System.Security.Principal.WindowsIdentity.GetCurrent.Name

        '':::Obtenemos el serial del Disco Duro
        'Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
        'LblSerialDD.Text = "Serial Disco Duro: " + serialDD.Properties("SerialNumber").Value.ToString

        ':::Obtenemos el serial de la Board
        'Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
        ''Dim serialBoard As String = ""
        'For Each serialB As ManagementObject In serial.Get()
        '    serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
        'Next
        Try
            Dim serial As ManagementObjectCollection = New ManagementClass("Win32_BaseBoard").GetInstances()
            Dim mbEnum As ManagementObjectCollection.ManagementObjectEnumerator = serial.GetEnumerator()
            mbEnum.MoveNext()
            serialBoard = DirectCast(mbEnum.Current, ManagementObject).Properties("SerialNumber").Value.ToString()

            Select Case Trim(serialBoard)
                Case "To be filled by O.E.M."
                    serialBoard = "Vacio"
                Case "Default string"
                    serialBoard = "Vacio"
                Case "*"
                    serialBoard = "Vacio"
                Case ""
                    serialBoard = "Vacio"
            End Select

        Catch ex As Exception
            serialBoard = "Vacio"
        End Try


        LblSerialBoard.Text = "Serial Board: " + serialBoard

    End Sub

    Public Shared Function GetMotherBoardID() As String
        Dim mbCol As ManagementObjectCollection = New ManagementClass("Win32_BaseBoard").GetInstances()
        'Enumerating the list 
        Dim mbEnum As ManagementObjectCollection.ManagementObjectEnumerator = mbCol.GetEnumerator()
        'Move the cursor to the first element of the list (and most probably the only one) 
        mbEnum.MoveNext()
        'Getting the serial number of that specific motherboard 
        Return DirectCast(mbEnum.Current, ManagementObject).Properties("SerialNumber").Value.ToString()

    End Function




    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If serialBoard = "" Then
                MsgBox("La serie del esquipo esta vacio.........", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf oSeguridadService.BuscarEquipo(CodUsu, serialBoard) Then
                MsgBox("El Equipo ya fue registrado para este usuario.", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim state_process As Boolean
                    state_process = oSeguridadService.InsertarEquipo(CodUsu, serialBoard, My.Computer.Info.OSFullName, ArquitecturaSO + " Bits", My.Computer.Name, System.Security.Principal.WindowsIdentity.GetCurrent.Name, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If state_process = True Then
                        MsgBox("Se agregó correctamente el equipo")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


End Class