Option Strict Off
Option Explicit On
Imports System.ServiceModel
Friend Class frmAdminLector
    Inherits System.Windows.Forms.Form
    Dim bConnected As Boolean
    Dim xBorrar As Boolean
    Private oMarcacionService As New MarcacionService.MarcacionServiceClient
    Private dtEquipo As DataTable
    Private sw As Integer

    Private Sub cmdBajarMarcas_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        MostrarMarcas()

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        frmCrtuser.Visible = False
    End Sub

    Public Sub cmdConnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConnect.Click
        Dim bconn As Boolean
        Dim mint As Short
        Dim SDKVersion As String
        Dim strVersion As String
        sw = 0
        xBorrar = True
        CZKEM1.BASE64 = 1
        bconn = False
        CZKEM1.GetSDKVersion(SDKVersion)
        labSDK.Text = "SDKVersion:" & SDKVersion

        If cmdConnect.Text = "Desconectar" Then
            CZKEM1.Beep(150)
            System.Windows.Forms.Application.DoEvents()
            CZKEM1.Disconnect()
            'Conn.Close()
            cmdConnect.Text = "Conectar"
            'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            StatusBar1.Items.Item(0).Text = "Desconectado"
            Exit Sub
        End If

        If txtPort.Text = "" Then Exit Sub
        bconn = CZKEM1.Connect_Net(CStr(txtIP.Text), CInt(txtPort.Text))
        If bconn Then
            cmdConnect.Text = "Desconectar"
            'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            StatusBar1.Items.Item(0).Text = "Coneccion Exitosa"
            CZKEM1.Beep(150)
            CZKEM1.GetFirmwareVersion(CShort(txtMachNum.Text), strVersion)
            labFirmV.Text = strVersion
            'Coneccion()
        Else
            'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            StatusBar1.Items.Item(0).Text = "Coneccion Fallada"
        End If

    End Sub

    Private Sub cmdCreate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCreate.Click
        Dim bCrtUser As Boolean
        Dim tmpData As String
        Dim xx As Object
        'UPGRADE_NOTE: Size was upgraded to Size_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Size_Renamed As Integer

        If sw = 1 Then
            'You can get finger template from db or other.
            'UPGRADE_WARNING: Couldn't resolve default property of object xx. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            xx = "mspZ1oh6jjlOwQu4PU5BGcG/TsEZxkU0ARUiSS9BEB2yS0FBSbJNQVJFLVpBFiO+ckEHODlWAQxKyEgBG2s8a4EIQEw+wRaBhzGBCecHaEEKhAtggQEEv1uBDU0YV0EHBiFzAQkhxV1BDEwVbYEJhgNoAQYSHFTBCHupUgEQd5QugQxrsiZBC0W7GAEMRakbQQhYLyEBCVADXQEHhEFUrBPQpHERARJXV1hVVVdeZ3MJFR0kJicmJysBElRTU09OUVVeaRUiJyorKikqLQISWVtZW15lbnYGDhcfIyQkJSgBElFQTkpHSEtPSTMvMDAwLS0tMAISXV9eX2NqcXYFCxIZHSAiJCYB"
            'UPGRADE_WARNING: Couldn't resolve default property of object xx. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CZKEM1.FPTempConvertStr(xx, tmpData, Size_Renamed)
            'UPGRADE_WARNING: Couldn't resolve default property of object xx. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            xx = tmpData
            'tmpData = "YYpGKDBSCkQMILFbhoggotJy4CFfgGaoE8MKV6cfgg5cgdfvF3CDjqf1OgsIRJsM7whGTOVcDEDw3JoMLRS4gQwxQuULCDZ4sQYMXhZ9OwgaLJnUCAZcXIYIIc0ooAhnlzmkCC9JBdwIONMg1QxJ/jzTDB3+JWwMEiiY0DA6fhG8SWqjxCxEV4sMAo6zLqrvAwnWkusy6u7rAwXClu8y8u7upwMFtpb3NzMu6qcB+ZqW8zuzdyqkewH5ipcve/+7KqCDAfl1gY2dvAAoToeypIYHAflihub9zCxih6rkjgcB+U6GXnGgTHaLrmHclwH5QoXZ2QCijTKp2aMB+TaF2QjUro125RljAfktLSUQ7MCkoM6LmJUbAfktLSUQ5LCMgRKKhA0bAfkyBRzwoGg1hUUahBDXAwVBPTUgaEANoWVBGQDo4wMFUVFZddgZ3amGhERLA"

            bCrtUser = CZKEM1.SetUserInfo(CShort(txtMacNum.Text), CInt(txtEnrollNum.Text), CStr(txtName.Text), CStr(txtPaw.Text), CShort(cmdPri.Text), CBool(cmbEnable.Text))
            If bCrtUser Then
                'UPGRADE_WARNING: Couldn't resolve default property of object xx. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                bCrtUser = CZKEM1.SetUserTmpStr(CShort(txtMacNum.Text), CInt(txtEnrollNum.Text), 0, xx)
                If bCrtUser Then
                    'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    StatusBar1.Items.Item(1).Text = "Se a Creado un Nuevo Usuario Satisfactoriamente"
                    frmCrtuser.Visible = False
                Else
                    'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    StatusBar1.Items.Item(1).Text = "Fallo la Creacion del Nuevo Usuario"
                End If
            End If
        End If
        Dim iEnrollNumber As Object
        If sw = 2 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object iEnrollNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            iEnrollNumber = CInt(txtEnrollNum.Text)
            'UPGRADE_WARNING: Couldn't resolve default property of object iEnrollNumber. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If CZKEM1.SetUserInfo(CShort(txtMacNum.Text), iEnrollNumber, CStr(txtName.Text), CStr(txtPaw.Text), CShort(cmdPri.Text), CBool(cmbEnable.Text)) Then
                'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                StatusBar1.Items.Item(1).Text = "Se Actualizo el Usuario Satisfactoriamente"
                frmCrtuser.Visible = False
            Else
                'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                StatusBar1.Items.Item(1).Text = "Fallo la Actualizacion del Usuario"
            End If
        End If
        cmdGetUserInfo_Click(cmdGetUserInfo, New System.EventArgs())

    End Sub

    Private Sub cmdDelAUser_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelAUser.Click
        Dim Bd As Boolean
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        If MsgBox("Seguro que Desea Eliminar al Usuario : " & lvX.FocusedItem.Text & " - " & lvX.Items.Item(lvX.FocusedItem.Index).SubItems(1).Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            CZKEM1.DelUserTmp(CShort(txtMachNum.Text), CInt(lvX.FocusedItem.Text), 0)
            Bd = CZKEM1.DeleteEnrollData(CShort(txtMachNum.Text), CInt(lvX.FocusedItem.Text), CShort(txtMachNum.Text), 0)
            If Bd Then
                'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                StatusBar1.Items.Item(1).Text = "Usuario Borrado Exitosamente"
            Else
                'UPGRADE_WARNING: Lower bound of collection StatusBar1.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                StatusBar1.Items.Item(1).Text = "Fallo el Borrado del Usuario"
            End If
            cmdGetUserInfo_Click(cmdGetUserInfo, New System.EventArgs())
        End If
    End Sub

    Private Sub cmdeditar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdeditar.Click
        Dim xIndex As Short
        frmCrtuser.Visible = True
        txtMacNum.Enabled = False
        txtEnrollNum.Enabled = False
        xIndex = lvX.FocusedItem.Index
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        txtEnrollNum.Text = lvX.Items.Item(xIndex).Text
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        txtName.Text = lvX.Items.Item(xIndex).SubItems(1).Text
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        If lvX.Items.Item(xIndex).SubItems(2).Text = "Null" Then
            txtPaw.Text = ""
        Else
            'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
            txtPaw.Text = lvX.Items.Item(xIndex).SubItems(2).Text
        End If
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        cmdPri.Text = lvX.Items.Item(xIndex).SubItems(3).Text
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        cmbEnable.Text = lvX.Items.Item(xIndex).SubItems(4).Text
        txtName.Focus()
        sw = 2
    End Sub

    Public Sub cmdGetUserInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGetUserInfo.Click

        Dim dwEnrollNmber As Integer
        'UPGRADE_NOTE: name was upgraded to name_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim name_Renamed As String
        Dim passWord As String
        Dim privilege As Short
        'UPGRADE_NOTE: Enabled was upgraded to Enabled_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Enabled_Renamed As Boolean
        Dim xx As Boolean
        Dim i As Integer
        lvX.Columns.Clear()
        lvX.Items.Clear()
        lvX.Refresh()
        'UPGRADE_WARNING: Lower bound of collection lvX.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        lvX.Columns.Insert(0, "IdPersonal", 100)

        'UPGRADE_WARNING: Lower bound of collection lvX.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        lvX.Columns.Insert(1, "Nombre", 150)
        'UPGRADE_WARNING: Lower bound of collection lvX.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        lvX.Columns.Insert(2, "Password", 100)
        'UPGRADE_WARNING: Lower bound of collection lvX.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        lvX.Columns.Insert(3, "Privilegio", 100)
        'UPGRADE_WARNING: Lower bound of collection lvX.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        lvX.Columns.Insert(4, "Habilitado", 100)
        i = 0 '1
        xx = CZKEM1.ReadAllUserID(CInt(txtMachNum.Text))
        If xx Then
            While CZKEM1.GetAllUserInfo(CInt(txtMachNum.Text), dwEnrollNmber, name_Renamed, passWord, privilege, Enabled_Renamed)
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                lvX.Items.Insert(i, IIf(IsDbNull(dwEnrollNmber), "", dwEnrollNmber))
                'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                With lvX.Items.Item(i)
                    If name_Renamed = "" Then
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        If lvX.Items.Item(i).SubItems.Count > 1 Then
                            lvX.Items.Item(i).SubItems(1).Text = "NUll"
                        Else
                            lvX.Items.Item(i).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NUll"))
                        End If
                    Else
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems(i) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If lvX.Items.Item(i).SubItems.Count > 1 Then
                            lvX.Items.Item(i).SubItems(1).Text = IIf(IsDbNull(name_Renamed), "", name_Renamed)
                        Else
                            lvX.Items.Item(i).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDbNull(name_Renamed), "", name_Renamed)))
                        End If
                    End If
                    If passWord = "" Then
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems() has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        If lvX.Items.Item(i).SubItems.Count > 2 Then
                            lvX.Items.Item(i).SubItems(2).Text = "Null"
                        Else
                            lvX.Items.Item(i).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Null"))
                        End If
                    Else
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Lower bound of collection lvX.ListItems(i) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        If lvX.Items.Item(i).SubItems.Count > 2 Then
                            lvX.Items.Item(i).SubItems(2).Text = IIf(IsDbNull(passWord), "", passWord)
                        Else
                            lvX.Items.Item(i).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDbNull(passWord), "", passWord)))
                        End If
                    End If
                    'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    'UPGRADE_WARNING: Lower bound of collection lvX.ListItems(i) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If lvX.Items.Item(i).SubItems.Count > 3 Then
                        lvX.Items.Item(i).SubItems(3).Text = IIf(IsDbNull(privilege), "", privilege)
                    Else
                        lvX.Items.Item(i).SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDbNull(privilege), "", privilege)))
                    End If
                    'UPGRADE_WARNING: Lower bound of collection lvX.ListItems has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    'UPGRADE_WARNING: Lower bound of collection lvX.ListItems(i) has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
                    'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                    If lvX.Items.Item(i).SubItems.Count > 4 Then
                        lvX.Items.Item(i).SubItems(4).Text = IIf(IsDbNull(Enabled_Renamed), "", Enabled_Renamed)
                    Else
                        lvX.Items.Item(i).SubItems.Insert(4, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDbNull(Enabled_Renamed), "", Enabled_Renamed)))
                    End If
                End With
                cmdeditar.Enabled = True
                cmdDelAUser.Enabled = True
            End While
        End If
    End Sub

    Private Sub cmdnuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdnuevo.Click
        frmCrtuser.Visible = True
        txtMacNum.Enabled = True
        txtEnrollNum.Enabled = True
        txtEnrollNum.Text = CStr(1)
        txtName.Text = ""
        txtPaw.Text = ""
        sw = 1
    End Sub

    Private Sub cmdSetDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetDevice.Click
        frmConfigurarLector.ShowDialog()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        MostrarMarcas()
    End Sub

    Public Sub MostrarMarcas()

        Try
            Dim resul As Boolean = False
            Dim dwEnrollNumber As Integer
            Dim dwVerifyMode As Integer
            Dim dwInOutMode As Integer
            Dim timeStr As String
            Dim i As Object
            Dim k As Integer
            Dim xFec, xHor As Date
            Dim xDirIp As String
            Dim Registro As New MarcacionService.Marcacion
            Dim persona As New MarcacionService.Persona
            Dim equipo As New MarcacionService.EquipoMarcacion

            ' xDirIp = Winsock1.LocalIP
            If xBorrar Then
                Progreso.Value = 0
                Progreso.Visible = False
            Else
                Progreso.Visible = True
                Progreso.Value = 10
            End If
            '*********
            Dim dwValue As Integer
            Dim bget As Boolean
            bget = Me.CZKEM1.GetDeviceInfo(CShort(Me.txtMachNum.Text), 2, dwValue)
            If bget = False Then
                Progreso.Value = 0
                StatusBar1.Items.Item(1).Text = "No Puede Leer Numero del Equipo"
                Exit Sub
            End If
            '**********
            lvX.Columns.Clear()
            lvX.Items.Clear()
            lvX.Refresh()
            lvX.Columns.Insert(0, "", "IdPersonal", 100)
            lvX.Columns.Insert(1, "", "Modo Verificacion", 100)
            lvX.Columns.Insert(2, "", "Fecha", 100)
            lvX.Columns.Insert(3, "", "Hora", 100)
            Progreso.Value = 20
            i = 0
            If CZKEM1.ReadGeneralLogData(CShort(txtMachNum.Text)) Then
                'i = i + 1
                Progreso.Value = 30
                While CZKEM1.GetGeneralLogDataStr(CShort(txtMachNum.Text), dwEnrollNumber, dwVerifyMode, dwInOutMode, timeStr)
                    lvX.Items.Add(i, "", dwEnrollNumber)
                    With lvX.Items.Item(i)
                        If lvX.Items.Item(i).SubItems.Count > 0 Then
                            lvX.Items.Item(i).SubItems(0).Text = IIf(IsDBNull(dwEnrollNumber), "", dwEnrollNumber)
                        Else
                            lvX.Items.Item(i).SubItems.Insert(0, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(dwEnrollNumber), "", dwEnrollNumber)))
                        End If

                        If lvX.Items.Item(i).SubItems.Count > 1 Then
                            lvX.Items.Item(i).SubItems(1).Text = IIf(IsDBNull(dwVerifyMode), "", dwVerifyMode)
                        Else
                            lvX.Items.Item(i).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(dwVerifyMode), "", dwVerifyMode)))
                        End If

                        If lvX.Items.Item(i).SubItems.Count > 2 Then
                            'lvX.Items.Item(i).SubItems(2).Text = IIf(IsDBNull(dwInOutMode), "", Format(timeStr, "dd/mm/yyyy"))
                            lvX.Items.Item(i).SubItems(2).Text = IIf(IsDBNull(dwInOutMode), "", Format(CDate(timeStr), "dd/MM/yyyy"))
                        Else
                            'lvX.Items.Item(i).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(dwInOutMode), "", Format(timeStr, "dd/mm/yyyy"))))
                            lvX.Items.Item(i).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(dwInOutMode), "", Format(CDate(timeStr), "dd/MM/yyyy"))))
                        End If
                        If lvX.Items.Item(i).SubItems.Count > 3 Then
                            'lvX.Items.Item(i).SubItems(3).Text = IIf(IsDBNull(timeStr), "", Format(timeStr, "hh:mm:ss"))
                            lvX.Items.Item(i).SubItems(3).Text = IIf(IsDBNull(timeStr), "", Format(CDate(timeStr), "HH:mm:ss"))
                        Else
                            'lvX.Items.Item(i).SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(timeStr), "", Format(timeStr, "hh:mm:ss"))))
                            lvX.Items.Item(i).SubItems.Insert(3, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, IIf(IsDBNull(timeStr), "", Format(CDate(timeStr), "HH:mm:ss"))))
                        End If
                    End With
                    xFec = Format(CDate(timeStr), "dd/MM/yyyy") 'Format(timeStr, "dd/mm/yyyy")
                    xHor = Format(CDate(timeStr), "HH:mm:ss") 'Format(timeStr, "hh:mm:ss")

                    '////////////////REGISTRARLO EN LA BASE DE DATOS//////////////////////
                    persona.IdPer = dwEnrollNumber
                    Registro.Persona = persona
                    equipo.IdEquipo = dwValue
                    Registro.EquipoMarcacion = equipo
                    Registro.Fecha = xFec
                    Registro.HoraMarcaIng = xHor
                    Registro.HoraMarcaSal = xHor
                    Registro.CodUsu = "AGENTE"
                    Registro.NomPc = Session.sNomPc
                    Registro.DirIp = Session.sDirIp
                    resul = oMarcacionService.InsertarMarcacionEquipo(Registro)
                    '/////////////////////////////////////////////////////////////////////

                    i = i + 1
                    Progreso.Maximum = 40 + i
                    Progreso.Value = 35 + i
                    Debug.Print(i)
                    lvX.Refresh()
                End While

                k = 40 + i
                Progreso.Maximum = 50 + i
                Progreso.Value = k

                If Check1.CheckState = 0 Then
                    MsgBox("Se descargo las marcas Satisfactoriamente", MsgBoxStyle.OkOnly, "Descarga Marcas")
                End If

                '////////////BORRAR LOS REGISTROS DEL LECTOR/////////////////
                'CZKEM1.ClearGLog(CShort(txtMachNum.Text))
                'MostrarMarcas()
                '////////////////////////////////////////////////////////////
                cmdeditar.Enabled = False
                cmdDelAUser.Enabled = False

                Progreso.Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error al descargar las marcas : " & ex.Message, MsgBoxStyle.Critical)
        End Try

        

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        frmConfigurarHora.ShowDialog()
    End Sub

    'Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
    '    If lvX.Items.Count = 0 Then Exit Sub
    '    If MsgBox("Seguro que Desea Borrar todos los Registros de Marcacion del Lector?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Borrar Registros") = MsgBoxResult.Yes Then
    '        CZKEM1.ClearGLog(CShort(txtMachNum.Text))
    '        MostrarMarcas()
    '        MsgBox("Se Borraron Todos los Registros del Lector con Exito", MsgBoxStyle.OKOnly, "Final Exitoso")
    '    End If
    'End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        Me.Close()
    End Sub

   

    Private Sub CZKEM1_OnConnected(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CZKEM1.OnConnected
        bConnected = True
        ShowButtonState()
    End Sub

    Private Sub CZKEM1_OnDisConnected(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CZKEM1.OnDisConnected
        bConnected = False
        ShowButtonState()
        cmdDelAUser.Enabled = False
        cmdeditar.Enabled = False
    End Sub

    Private Sub frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        bConnected = False

        llenarCombos()
    End Sub

    Sub ShowButtonState()
        Command1.Enabled = bConnected
        Command2.Enabled = bConnected
        cmdGetUserInfo.Enabled = bConnected
        '     cmdDelAUser.Enabled = bConnected
        cmdSetDevice.Enabled = bConnected
        Command3.Enabled = bConnected
        cmdnuevo.Enabled = bConnected
        '      cmdeditar.Enabled = bConnected
        Check1.Enabled = bConnected

        frmConfigurarLector.cmdBeep.Enabled = bConnected
        frmConfigurarLector.cmdDisableDT.Enabled = bConnected
        frmConfigurarLector.cmdDisEnable.Enabled = bConnected
        frmConfigurarLector.cmdDisEnableClock.Enabled = bConnected
        frmConfigurarLector.cmdEnable.Enabled = bConnected
        frmConfigurarLector.cmdEnableClock.Enabled = bConnected
        frmConfigurarLector.CmdFPConver.Enabled = bConnected
        frmConfigurarLector.cmdGetDeviceIP.Enabled = bConnected
        frmConfigurarLector.cmdGetDeviceMAC.Enabled = bConnected
        frmConfigurarLector.cmdGetDevInfo.Enabled = bConnected
        frmConfigurarLector.cmdGetDevInfo.Enabled = bConnected
        frmConfigurarLector.cmdGetDeviStat.Enabled = bConnected
        frmConfigurarLector.cmdGetProductCode.Enabled = bConnected
        frmConfigurarLector.cmdGetSerialNumber.Enabled = bConnected
        frmConfigurarLector.cmdGetSN.Enabled = bConnected
        frmConfigurarLector.cmdPlayVoiceByIndex.Enabled = bConnected
        frmConfigurarLector.cmdRestartDevice.Enabled = bConnected
        frmConfigurarLector.cmdSetDeviceIP.Enabled = bConnected
        frmConfigurarLector.cmdSetDeviceMAC.Enabled = bConnected
        frmConfigurarLector.cmdWriteLcd.Enabled = bConnected
        frmConfigurarLector.Command1.Enabled = bConnected

        frmConfigurarHora.cmdDateFormat.Enabled = bConnected
        frmConfigurarHora.cmdGetTime.Enabled = bConnected
        frmConfigurarHora.cmdSetDeviceTime.Enabled = bConnected
        frmConfigurarHora.cmdUpdateFirmware.Enabled = bConnected
    End Sub

    Private Sub frm1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If bConnected = True Then
            'Conn.Close()
            Finalizar()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If Check1.CheckState = 1 Then
            MostrarMarcas()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================== EQUIPO ================================================
            dtEquipo = oMarcacionService.MostrarLectores().Tables(0)
            cmbEquipo.DataSource = dtEquipo
            cmbEquipo.DisplayMember = dtEquipo.Columns("DesEquipo").ToString
            cmbEquipo.ValueMember = dtEquipo.Columns("IdEquipo").ToString 
            cmbEquipo.SelectedIndex = 1
            dtEquipo = Nothing

            txtIP.Text = oMarcacionService.ObtenerDirIp(cmbEquipo.SelectedValue)
            txtPort.Text = oMarcacionService.ObtenerPuerto(cmbEquipo.SelectedValue)
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Finalizar()
        Try
            oMarcacionService.Close()

        Catch ex As TimeoutException
            oMarcacionService.Abort()

        Catch ex As CommunicationException
            oMarcacionService.Abort()

        End Try
    End Sub

    Private Sub cmbEquipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEquipo.SelectionChangeCommitted
        Try
           
            txtIP.Text = oMarcacionService.ObtenerDirIp(cmbEquipo.SelectedValue)
            txtPort.Text = oMarcacionService.ObtenerPuerto(cmbEquipo.SelectedValue)

        Catch ex As Exception
            MsgBox("ERROR AL SELECCIONAR EQUIPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class