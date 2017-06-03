Imports Renci.SshNet
Imports System.Threading.Thread
Imports System.ComponentModel

Public Class DeployForm

#Region "Var"

    'Global vars
    Private itnDeploy As Intent
    Private intSource As SourceEnum
    Private IP As String
    Private Port As String
    Private User As String
    Private Passwd As String
    Private Param As String = ""
    Private iniServer As String = Application.StartupPath & "\Servers.ini"

    Public Enum SourceEnum
        FromLocal = 0
        FromBoomSource = 1
    End Enum


#End Region

#Region "Form Configuration"

    'Form Load
    Private Sub DeployForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Me.PackageSource
            Case SourceEnum.FromLocal
                bgwInstallFromLocal.RunWorkerAsync()
            Case SourceEnum.FromBoomSource
                bgwInstallFromSource.RunWorkerAsync()
        End Select
    End Sub

    'Form Closing
    Private Sub DeployForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        txtMain.Clear()
    End Sub

    'Property Get Intent 
    Public Property DeployIntent As Intent
        Set(value As Intent)
            itnDeploy = value
        End Set
        Get
            Return itnDeploy
        End Get
    End Property

    'Property whether package source is from Boom Source or local file
    Public Property PackageSource As SourceEnum
        Set(value As SourceEnum)
            intSource = value
        End Set
        Get
            Return intSource
        End Get
    End Property

#End Region

#Region "Functions"
    'Logging output to textbox
    Private Sub Loggin(ByVal str As String)
        txtMain.AppendText(str)
    End Sub
#End Region

#Region "Local Install"

    'Main Thread
    Private Sub bgwInstallFromLocal_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwInstallFromLocal.DoWork
        'Get connection info from intent
        IP = Me.DeployIntent.GetExtra("IP")
        Port = Me.DeployIntent.GetExtra("Port")
        User = Me.DeployIntent.GetExtra("User")
        Passwd = Me.DeployIntent.GetExtra("Passwd")

        'Get Params If Needed
        Dim strInput As String
        If IO.File.Exists(Application.StartupPath & "\Temp\param") = True Then
            Dim sr As New IO.StreamReader(Application.StartupPath & "\Temp\param", System.Text.Encoding.UTF8)
            Dim vars As String
            Do
                vars = sr.ReadLine()
                If "" = vars Then Exit Do
InputParam:
                strInput = InputBox(vars)
                If "" <> strInput Then
                    Param = Param & " " & InputBox(vars)
                Else
                    MessageBox.Show(My.Resources.DP_Param_Empty, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GoTo InputParam
                End If
            Loop
        End If


        'Create SFTP Connection
        Dim sftpc As SftpClient
        Try
            bgwInstallFromLocal.ReportProgress(5)
            sftpc = New SftpClient(IP, Port, User, Passwd)
            bgwInstallFromLocal.ReportProgress(6)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(61, ex.Message)
            Exit Sub
        End Try


        'Establish SFTP Connection
        Try
            bgwInstallFromLocal.ReportProgress(9)
            sftpc.Connect()
            bgwInstallFromLocal.ReportProgress(10)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(11, ex.Message)
            Exit Sub
        End Try


        'Upload INSTALL.SH
        Try
            Try
                bgwInstallFromLocal.ReportProgress(19)
                sftpc.ChangeDirectory("/root/boomvm")
                bgwInstallFromLocal.ReportProgress(20)
            Catch ex0 As Exception
                bgwInstallFromLocal.ReportProgress(21, ex0.Message)
                Try
                    bgwInstallFromLocal.ReportProgress(14)
                    sftpc.CreateDirectory("/root/boomvm")
                    bgwInstallFromLocal.ReportProgress(15)
                    bgwInstallFromLocal.ReportProgress(17)
                    sftpc.ChangeDirectory("/root/boomvm")
                    bgwInstallFromLocal.ReportProgress(18)
                Catch ex1 As Exception
                    bgwInstallFromLocal.ReportProgress(22, ex1.Message)
                    Exit Sub
                End Try
            End Try
            bgwInstallFromLocal.ReportProgress(49)
            Dim stm As New IO.FileStream(Application.StartupPath & "\Temp\install.sh", IO.FileMode.Open)
            sftpc.UploadFile(stm, "/root/boomvm/install.sh", True)
            stm.Close()
            stm.Dispose()
            bgwInstallFromLocal.ReportProgress(50)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(51, ex.Message)
            Exit Sub
        End Try


        'Create SSH Connection
        Dim sshc As SshClient
        Try
            bgwInstallFromLocal.ReportProgress(54)
            sshc = New SshClient(IP, Port, User, Passwd)
            bgwInstallFromLocal.ReportProgress(55)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(56, ex.Message)
            Exit Sub
        End Try


        'Establish SSH Connection
        Try
            bgwInstallFromLocal.ReportProgress(59)
            sshc.Connect()
            bgwInstallFromLocal.ReportProgress(60)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(61, ex.Message)
            Exit Sub
        End Try


        'Grant Execution Permission
        Dim cmd As SshCommand
        Try
            bgwInstallFromLocal.ReportProgress(64)
            cmd = sshc.CreateCommand("chmod +x /root/boomvm/install.sh")
            cmd.Execute()
            bgwInstallFromLocal.ReportProgress(65)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(66, ex.Message)
            Exit Sub
        End Try

        'Process Installation
        Try
            bgwInstallFromLocal.ReportProgress(98)
            cmd = sshc.CreateCommand("bash /root/boomvm/install.sh" & Param)
            Dim result As String = cmd.Execute()
            bgwInstallFromLocal.ReportProgress(100, result)
        Catch ex As Exception
            bgwInstallFromLocal.ReportProgress(99, ex.Message)
            Exit Sub
        End Try

    End Sub

    'Apply UI Changes
    Private Sub bgwInstallFromLocal_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwInstallFromLocal.ProgressChanged
        Select Case e.ProgressPercentage
            Case 5
                Loggin(My.Resources.DP_SFTP_Start)
            Case 6
                proMain.Value = 6
                Loggin(My.Resources.DP_Success & vbCrLf)
            Case 61
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 9
                Loggin(My.Resources.DP_SFTP_Connect)
            Case 10
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 10
            Case 11
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 19
                Loggin(My.Resources.DP_Change_Directory)
            Case 20
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 20
            Case 21
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 14
                Loggin(My.Resources.DP_Create_Directory)
            Case 15
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 15
            Case 17
                Loggin(My.Resources.DP_Change_Directory)
            Case 18
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 20
            Case 22
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 49
                Loggin(My.Resources.DP_Upload_Script)
            Case 50
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 50
            Case 51
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 54
                Loggin(My.Resources.DP_SSH_Start)
            Case 55
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 55
            Case 56
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 59
                Loggin(My.Resources.DP_SSH_Connect)
            Case 60
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 60
            Case 61
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 64
                Loggin(My.Resources.DP_Add_Permision)
            Case 65
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 65
            Case 66
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
            Case 98
                Loggin(My.Resources.DP_Install)
            Case 100
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 100
                Loggin(vbCrLf)
                Loggin(My.Resources.DP_Done_Install & vbCrLf)
                Loggin(vbCrLf & "====================" & vbCrLf)
                txtMain.AppendText(e.UserState)
            Case 99
                Loggin(My.Resources.DP_Failed & e.UserState & vbCrLf)
        End Select
    End Sub

#End Region

#Region "Source Install"

    'Main Thread
    Private Sub bgwInstallFromSource_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwInstallFromSource.DoWork
        'Get Package
        Dim pkgDeploy As BoomPackage = Me.DeployIntent.GetExtra("Package")

        'Get Server Info from Intent
        Dim strServer As String = Me.DeployIntent.GetExtra("Server")
        IP = INIGet(strServer, "IP", Nothing, iniServer)
        Port = INIGet(strServer, "Port", Nothing, iniServer)
        User = INIGet(strServer, "User", Nothing, iniServer)
        Passwd = INIGet(strServer, "Passwd", Nothing, iniServer)

        'Get Params If Needed
        If pkgDeploy.NeedParam = True Then
            For Each strParam As String In pkgDeploy.Params
                If strParam = "" Then Exit For
GetParam:
                Dim strInput = InputBox(strParam)
                If strInput = "" Then
                    MessageBox.Show(My.Resources.DP_Param_Empty, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GoTo GetParam
                Else
                    Param &= strInput
                    Param &= " "
                End If
            Next
        End If

        'Create SSH Connection
        Dim sshc As SshClient
        Try
            bgwInstallFromSource.ReportProgress(1)
            sshc = New SshClient(IP, Port, User, Passwd)
            bgwInstallFromSource.ReportProgress(2)
        Catch ex As Exception
            bgwInstallFromSource.ReportProgress(3, ex.Message)
            Exit Sub
        End Try

        'Establish SSH Connection
        Try
            bgwInstallFromSource.ReportProgress(4)
            sshc.Connect()
            bgwInstallFromSource.ReportProgress(5)
        Catch ex As Exception
            bgwInstallFromSource.ReportProgress(6, ex.Message)
            Exit Sub
        End Try

        'Get Installation Script & Grant Executable Permission
        Dim cmd As SshCommand
        Try
            'Create Directory
            bgwInstallFromSource.ReportProgress(7)
            cmd = sshc.CreateCommand("mkdir -p /root/boomvm/")
            cmd.Execute()
            bgwInstallFromSource.ReportProgress(8)

            'Download Script
            bgwInstallFromSource.ReportProgress(9)
            cmd = sshc.CreateCommand("wget " & pkgDeploy.InstallScript & " -O /root/boomvm/install.sh")
            cmd.Execute()
            bgwInstallFromSource.ReportProgress(10)

            'Grant Permission
            bgwInstallFromSource.ReportProgress(11)
            cmd = sshc.CreateCommand("chmod +x /root/boomvm/install.sh")
            cmd.Execute()
            bgwInstallFromSource.ReportProgress(12)
        Catch ex As Exception
            bgwInstallFromSource.ReportProgress(13, ex.Message)
            Exit Sub
        End Try

        'Process Installation
        Try
            bgwInstallFromSource.ReportProgress(14)
            cmd = sshc.CreateCommand("bash /root/boomvm/install.sh " & Param)
            Dim result As String = cmd.Execute()
            bgwInstallFromSource.ReportProgress(15, result)
        Catch ex As Exception
            bgwInstallFromSource.ReportProgress(16, ex.Message)
            Exit Sub
        End Try

    End Sub

    'Apply UI Changes
    Private Sub bgwInstallFromSource_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwInstallFromSource.ProgressChanged
        Select Case e.ProgressPercentage
            'Start SSH
            Case 1
                Loggin(My.Resources.DP_SSH_Start)
            Case 2
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 10
            Case 3
                Loggin(My.Resources.DP_Failed & e.UserState)
            'SSH Connect
            Case 4
                Loggin(My.Resources.DP_SSH_Connect)
            Case 5
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 20
            Case 6
                Loggin(My.Resources.DP_Failed & e.UserState)
            'Create Directory
            Case 7
                Loggin(My.Resources.DP_Create_Directory)
            Case 8
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 30
            'Download Script
            Case 9
                Loggin(My.Resources.DP_Download_Script)
            Case 10
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 40
            'Grant Permission
            Case 11
                Loggin(My.Resources.DP_Add_Permision)
            Case 12
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 50
            'Prepare script failed
            Case 13
                Loggin(My.Resources.DP_Failed & e.UserState)
            'Install
            Case 14
                Loggin(My.Resources.DP_Install)
            Case 15
                Loggin(My.Resources.DP_Success & vbCrLf)
                proMain.Value = 100
                Loggin(vbCrLf)
                Loggin(My.Resources.DP_Done_Install & vbCrLf)
                Loggin(vbCrLf & "====================" & vbCrLf)
                txtMain.AppendText(e.UserState)
            Case 16
                Loggin(My.Resources.DP_Failed & e.UserState)
        End Select
    End Sub

#End Region

End Class
