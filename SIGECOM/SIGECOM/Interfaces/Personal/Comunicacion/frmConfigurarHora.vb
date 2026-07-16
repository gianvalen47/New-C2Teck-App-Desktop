Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmConfigurarHora
    Inherits System.Windows.Forms.Form
    'Updates to the SDK need to address:
    '
    '   Function for setting date time - 'SetDeviceTime2'
    '
    '    Fix for 'SetEnrollmentData' returning ¡°ERR_INVALID_PARAM¡±
    '    Programming samples with sample function arguments to verify performance of these three functions:
    '            SetEnrollDataStr
    '            SetUserTmp,
    '            SetUserTmpStr
    '
    '    Documentation on SLog records.
    '
    '    How to change the Date Delimiter using the SetDeviceInfo command
    '
    '    How to program the "Match Threshold" value in the clock
    '
    '    How to program the clock for 1:1 or 1:x biometrics
    '
    '    How to program the 1:1 threshold value
    '
    '    How to program the date time display format on the clock to Month, Day, Year (U.S. format)


    Dim vMachineNumber As Object
    Dim bConnected As Boolean
    'Public connFP As New ADODB.Connection
    'Public recFP As New ADODB.Recordset
    'Set rs_gBlood = HisConn.Execute(StrSqlQueryCondition)
    Function Str2Byte(ByRef s As String, ByRef Index As Short) As Byte
        Dim b1, b2 As Byte
        Dim s1, s2 As String

        s1 = Mid(s, Index * 2 + 1, 1)
        s2 = Mid(s, Index * 2 + 2, 1)
        If s1 >= "A" Then
            b1 = Asc(s1) - Asc("A") + 10
        Else
            b1 = Asc(s1) - Asc("0")
        End If
        If s2 >= "A" Then
            b2 = Asc(s2) - Asc("A") + 10
        Else
            b2 = Asc(s2) - Asc("0")
        End If
        Str2Byte = b1 * 16 + b2
    End Function

    Function Str2ByteArray(ByRef s As String, ByRef b() As Byte) As Short
        Dim i As Short
        Dim l As Short
        l = Len(s) / 2
        For i = 0 To l - 1 Step 1
            b(i) = Str2Byte(s, i)
        Next
        Str2ByteArray = l
    End Function

    Function Str2LongArray(ByRef s As String, ByRef ldata() As Integer) As Short
        Dim i As Short
        Dim lbyte, llong As Short
        Dim l As Integer
        Dim b(1024 * 4) As Byte
        lbyte = Str2ByteArray(s, b)
        llong = lbyte / 4
        If llong * 4 < lbyte Then llong = llong + 1
        For i = 0 To llong - 1 Step 1
            l = b(i * 4 + 3)
            If l > 127 Then
                l = (((l - 128) * 256 + b(i * 4 + 2)) * 256 + b(i * 4 + 1)) * 256 + b(i * 4)
                l = l - 2147483647
                l = l - 1
            Else
                l = ((l * 256 + b(i * 4 + 2)) * 256 + b(i * 4 + 1)) * 256 + b(i * 4)
            End If
            ldata(i) = l
        Next
        Str2LongArray = llong
    End Function

    Private Sub cmdDateFormat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDateFormat.Click
        'UPGRADE_WARNING: Couldn't resolve default property of object vMachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If frmAdminLector.CZKEM1.SetDeviceInfo(vMachineNumber, 34, cmbDateFormats.SelectedIndex) Then
            lblInfo.Text = "Seteo del Formaro de Fecha Correctamente"
        Else
            lblInfo.Text = "Seteo del Formato de Fecha Fallo"
        End If
    End Sub


    Private Sub cmdGetTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetTime.Click
        Dim iMinute, iDay, iYear, iMonth, iHour, iSecond As Integer

        'UPGRADE_WARNING: Couldn't resolve default property of object vMachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If frmAdminLector.CZKEM1.GetDeviceTime(vMachineNumber, iYear, iMonth, iDay, iHour, iMinute, iSecond) Then
            lblInfo.Text = "La Fecha y Hora del Relog es : " & iDay & "-" & iMonth & "-" & iYear & " " & iHour & ":" & iMinute & ":" & iSecond
        Else
            lblInfo.Text = "No se pudo leer la Fecha y Hora del Relog"
        End If
    End Sub

    Private Sub cmdSetDeviceTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetDeviceTime.Click
        Dim iMinute, iDay, iYear, iMonth, iHour, iSecond As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object iYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iYear = CInt(txtYear.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iMonth = CInt(txtMonth.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iDay. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iDay = CInt(txtDay.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iHour. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iHour = CInt(txtHour.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iMinute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iMinute = CInt(txtMinute.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iSecond. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        iSecond = CInt(txtSecond.Text)
        'UPGRADE_WARNING: Couldn't resolve default property of object iSecond. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iMinute. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iHour. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iDay. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iMonth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object iYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object vMachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Not frmAdminLector.CZKEM1.SetDeviceTime2(vMachineNumber, iYear, iMonth, iDay, iHour, iMinute, iSecond) Then
            lblInfo.Text = "Seteo de la Hora fallo"
        Else
            lblInfo.Text = "Seteo de la Hora Correctamente"
        End If
    End Sub

    Private Sub cmdUpdateFirmware_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdateFirmware.Click
        Dim sFile As Object
        On Error GoTo cancelline
        CommonDialog1Open.ShowDialog()

        'UPGRADE_WARNING: Couldn't resolve default property of object sFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sFile = CommonDialog1Open.FileName
        'Disbale device to speed up firmware transfer
        'UPGRADE_WARNING: Couldn't resolve default property of object vMachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmAdminLector.CZKEM1.DisableDeviceWithTimeOut(vMachineNumber, 10)
        'UPGRADE_WARNING: Couldn't resolve default property of object sFile. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If frmAdminLector.CZKEM1.UpdateFirmware(sFile) Then
            lblInfo.Text = "Update Firmware success."
        Else
            lblInfo.Text = "Update Firmware fail."
        End If
cancelline:
    End Sub

    Private Sub frm2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim s As String
        cmbDateFormats.SelectedIndex = 0
        bConnected = False
        frmAdminLector.CZKEM1.BASE64 = 0
        'UPGRADE_WARNING: Couldn't resolve default property of object vMachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        vMachineNumber = 1
        'connFP.Open "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & "FP1500.MDB;Persist Security Info=False"
        frmAdminLector.CZKEM1.GetSDKVersion(s)
        Label6.Text = "Version : " & s
        txtDay.Text = CStr(VB.Day(Today))
        txtMonth.Text = CStr(Month(Today))
        txtYear.Text = CStr(Year(Today))

        txtHour.Text = CStr(Hour(TimeOfDay))
        txtMinute.Text = CStr(Minute(TimeOfDay))
        txtSecond.Text = CStr(Second(TimeOfDay))
    End Sub
End Class