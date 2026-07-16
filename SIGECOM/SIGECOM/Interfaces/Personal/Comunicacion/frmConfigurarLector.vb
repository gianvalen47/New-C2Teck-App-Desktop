Option Strict Off
Option Explicit On
Friend Class frmConfigurarLector
    Inherits System.Windows.Forms.Form
    '**********************************************
    'Time:2005-6-22                               *
    'purpose:Demo                                 *
    'author:YongHong Pei,work for zksoftware      *
    'contact:pyhppp@hotmail.com                   *
    '**********************************************
    'follow code get access testing by zkemsdk 5.10.90

    Private Sub cmdBeep_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBeep.Click
        'Some machine does not,for example,F4 can
        frmAdminLector.CZKEM1.Beep(150)
    End Sub

    Private Sub cmdDisableDT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisableDT.Click
        frmAdminLector.CZKEM1.DisableDeviceWithTimeOut(CShort(frmAdminLector.txtMachNum.Text), CShort(txtDisableDeviceT.Text))
    End Sub

    Private Sub cmdDisEnable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisEnable.Click
        'The device will be in work state
        frmAdminLector.CZKEM1.EnableDevice(CShort(frmAdminLector.txtMachNum.Text), False)
    End Sub

    Private Sub cmdDisEnableClock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisEnableClock.Click
        'pls look the time of machine
        frmAdminLector.CZKEM1.EnableClock(0)
    End Sub

    Private Sub cmdEnable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnable.Click
        frmAdminLector.CZKEM1.EnableDevice(CShort(frmAdminLector.txtMachNum.Text), True)
    End Sub

    Private Sub cmdEnableClock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnableClock.Click
        'pls look the time of machine
        frmAdminLector.CZKEM1.EnableClock(1)
    End Sub

    Private Sub CmdFPConver_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdFPConver.Click
        Dim TmpData1 As Object
        Dim TmpData2 As String
        'UPGRADE_NOTE: Size was upgraded to Size_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Size_Renamed As Integer
        'UPGRADE_WARNING: Couldn't resolve default property of object TmpData1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        TmpData1 = "ocojg52rWoEOOq1egQw1rEtBFp4uRAESmkBLQRZ0wlLBB21BKUEM3EIuQTPmKGhBCCm8fEkdw7MnQRE6QCXBC9DDVVEE3Kk3QR0iFjvBDRJAckEMz5VggQYbMn1BDy8uKwkNMItPyQ0VL0uBSJozS4FQhR8/ARSDoTHBIl0sIYEKQKYlghJDoxlBD02aKcERZJwaQRBbhioBKHkRS4EJhyUygVtEozPBPwi4PsEQij5DQQl8HXQJDZtkLBOrMM8LEBHCAgQPFBgPBoHAwgKjrfxTfBfAwgIEDKLaiZwdwMF1pKzLrMuqIcDBc6WZ693rmJrAwW+km87vzJmCwMFmoa3/DBWjy5qG"

        'UPGRADE_WARNING: Couldn't resolve default property of object TmpData1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmAdminLector.CZKEM1.FPTempConvertStr(TmpData1, TmpData2, Size_Renamed)
        txtFPTepLate1.Text = TmpData2
        Size_Renamed = Len(TmpData2)
    End Sub

    Private Sub cmdGetDeviceIP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetDeviceIP.Click
        Dim IPAddr As String

        frmAdminLector.CZKEM1.GetDeviceIP(CShort(frmAdminLector.txtMachNum.Text), IPAddr)
        txtDeviceIP.Text = IPAddr
    End Sub

    Private Sub cmdGetDeviceMAC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetDeviceMAC.Click
        Dim sMac As String

        frmAdminLector.CZKEM1.GetDeviceMAC(CShort(frmAdminLector.txtMachNum.Text), sMac)
        txtGetDeviceMAC.Text = sMac
    End Sub

    Private Sub cmdGetDevInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetDevInfo.Click
        Dim i As Short
        Dim dwValue As Integer
        Dim bget As Boolean

        For i = 1 To 35
            bget = frmAdminLector.CZKEM1.GetDeviceInfo(CShort(frmAdminLector.txtMachNum.Text), i, dwValue)
            If bget = False Then Exit Sub
            If i = 1 Then
                ls2.Items.Add("Max num of manager:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 2 Then
                ls2.Items.Add("Machine num:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 3 Then
                If dwValue = 0 Then
                    ls2.Items.Add("Lanage:English")
                    ls2.Refresh()
                ElseIf dwValue = 1 Then
                    ls2.Items.Add("Lanage:Chinese")
                    ls2.Refresh()
                ElseIf dwValue = 2 Then
                    ls2.Items.Add("Lanage:Korea")
                    ls2.Refresh()
                End If
            End If
            If i = 4 Then
                ls2.Items.Add("Close Machine self-motion time:" & dwValue & "M")
                ls2.Refresh()
            End If
            If i = 5 Then
                ls2.Items.Add("Export signal of controling mentor:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 6 Then
                ls2.Items.Add("Max num of Attdance alarm:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 7 Then
                ls2.Items.Add("Max num of manage newsreel alarm:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 8 Then
                ls2.Items.Add("Min space of two validate:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 9 Then
                If dwValue <> 6 Then
                    ls2.Items.Add("Rate:" & 1200 * (dwValue + 1) & "bps")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("Rate:115200bps")
                    ls2.Refresh()
                End If
            End If
            If i = 10 Then
                If dwValue = 0 Then
                    ls2.Items.Add("parity check:NO")
                    ls2.Refresh()
                ElseIf dwValue = 1 Then
                    ls2.Items.Add("Parity check:even")
                    ls2.Refresh()
                ElseIf dwValue = 2 Then
                    ls2.Items.Add("Parity check:odd")
                    ls2.Refresh()
                End If
            End If
            If i = 11 Then
                ls2.Items.Add("Stop sing:" & (dwValue + 1) * 2 & "Bits")
                ls2.Refresh()
            End If
            If i = 12 Then
                If dwValue = 0 Then
                    ls2.Items.Add(CStr(CDbl("Data segmentation sign:") / CDbl("")))
                    ls2.Refresh()
                ElseIf dwValue = 1 Then
                    ls2.Items.Add("Data segmentation sign:-")
                    ls2.Refresh()
                End If
            End If
            If i = 13 Then
                If dwValue = 1 Then
                    ls2.Items.Add("Connect net:YES")
                    ls2.Refresh()
                ElseIf dwValue = 0 Then
                    ls2.Items.Add("Connect net:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 14 Then
                If dwValue = 1 Then
                    ls2.Items.Add("RS232 Connect:YES")
                    ls2.Refresh()
                ElseIf dwValue = 0 Then
                    ls2.Items.Add("RS232 Connect:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 15 Then
                If dwValue = 1 Then
                    ls2.Items.Add("RS485 Connect:YES")
                    ls2.Refresh()
                ElseIf dwValue = 0 Then
                    ls2.Items.Add("RS485 Connect:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 16 Then
                If dwValue = 1 Then
                    ls2.Items.Add("voice register:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("voice register:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 17 Then
                ls2.Items.Add("validate speed:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 18 Then
                ls2.Items.Add("idlesse times:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 19 Then
                ls2.Items.Add("time of closing machine:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 20 Then
                ls2.Items.Add("time of setup machine:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 21 Then
                ls2.Items.Add("time of sleep:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 22 Then
                ls2.Items.Add("self-motion beep:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 23 Then
                ls2.Items.Add("Match threhold:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 24 Then
                ls2.Items.Add("mistach threshord:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 25 Then
                If dwValue = 1 Then
                    ls2.Items.Add("1:1:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("1:1:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 26 Then
                If dwValue = 1 Then
                    ls2.Items.Add("Show score:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("Show score:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 27 Then
                ls2.Items.Add("Combination number of unlock persons:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 28 Then
                If dwValue = 1 Then
                    ls2.Items.Add("Whether to use card for verification:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("Whether to use card for verification:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 29 Then
                ls2.Items.Add("Network speed:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 30 Then
                If dwValue = 1 Then
                    ls2.Items.Add("Must register card No:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("Must register card No:NO")
                    ls2.Refresh()
                End If
            End If
            If i = 31 Then
                ls2.Items.Add("retention time for machine under temporary status:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 32 Then
                ls2.Items.Add("Type retention time:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 33 Then
                ls2.Items.Add("Retention time for menu:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 34 Then
                ls2.Items.Add("Date formate:" & dwValue & "")
                ls2.Refresh()
            End If
            If i = 35 Then
                If dwValue = 1 Then
                    ls2.Items.Add("Whether is 1: 1 match or not?:YES")
                    ls2.Refresh()
                Else
                    ls2.Items.Add("Whether is 1: 1 match or not?:NO")
                    ls2.Refresh()
                End If
            End If
        Next i
    End Sub

    Private Sub cmdGetDeviStat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetDeviStat.Click
        Dim i As Short
        Dim dwValue As Integer

        For i = 1 To 6
            frmAdminLector.CZKEM1.GetDeviceStatus(CShort(frmAdminLector.txtMachNum.Text), i, dwValue)
            If i = 1 Then
                ls1.Items.Add("Manage number:" & dwValue & "")
                ls1.Refresh()
            End If
            If i = 2 Then
                ls1.Items.Add("User number:" & dwValue & "")
                ls1.Refresh()
            End If
            If i = 3 Then
                ls1.Items.Add("Finger templata number:" & dwValue & "")
                ls1.Refresh()
            End If
            If i = 4 Then
                ls1.Items.Add("PassWord number:" & dwValue & "")
                ls1.Refresh()
            End If
            If i = 5 Then
                ls1.Items.Add("Manage run number:" & dwValue & "")
                ls1.Refresh()
            End If
            If i = 6 Then
                ls1.Items.Add("Attdance number:" & dwValue & "")
                ls1.Refresh()
            End If
        Next
    End Sub

    Private Sub cmdGetProductCode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetProductCode.Click
        Dim lpsxProductCode As String

        frmAdminLector.CZKEM1.GetProductCode(CShort(frmAdminLector.txtMachNum.Text), lpsxProductCode)
        txtProductCode.Text = lpsxProductCode
    End Sub

    Private Sub cmdGetSerialNumber_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetSerialNumber.Click
        Dim dwSerialNumber As String

        frmAdminLector.CZKEM1.GetSerialNumber(CShort(frmAdminLector.txtMachNum.Text), dwSerialNumber)
        txtSerialNumber.Text = dwSerialNumber
    End Sub

    Private Sub cmdGetSN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetSN.Click
        Dim SensorSN As String

        frmAdminLector.CZKEM1.GetSensorSN(1, SensorSN)
    End Sub

    Private Sub cmdSetDeviceIP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetDeviceIP.Click
        frmAdminLector.CZKEM1.SetDeviceIP(CShort(frmAdminLector.txtMachNum.Text), txtSetIP.Text)
    End Sub

    Private Sub cmdSetDeviceMAC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetDeviceMAC.Click
        frmAdminLector.CZKEM1.SetDeviceMAC(CShort(frmAdminLector.txtMachNum.Text), txtSDeviceMAC.Text)
    End Sub

    Private Sub cmdWriteLcd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWriteLcd.Click
        frmAdminLector.CZKEM1.ClearLCD()
        frmAdminLector.CZKEM1.EnableClock(0)
        frmAdminLector.CZKEM1.WriteLCD(0, 0, "Buena Hermano!Que")
        frmAdminLector.CZKEM1.WriteLCD(1, 0, "Estas Haciendo!!!")
    End Sub

    Private Sub cmdRestartDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRestartDevice.Click
        frmAdminLector.CZKEM1.RestartDevice(CShort(frmAdminLector.txtMachNum.Text))
    End Sub

    Private Sub cmdPlayVoiceByIndex_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlayVoiceByIndex.Click
        frmAdminLector.CZKEM1.PlayVoiceByIndex(2)
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim MachineNumber As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object MachineNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        frmAdminLector.CZKEM1.PowerOffDevice(MachineNumber)
        frmAdminLector.cmdConnect_Click(Nothing, New System.EventArgs())
    End Sub
End Class