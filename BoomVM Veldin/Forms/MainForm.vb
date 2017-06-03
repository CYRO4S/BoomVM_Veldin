Imports System.ComponentModel
Imports System.Xml

Public Class MainForm

#Region "Definitions"

    'Server configuration file
    Private strConfig As String = Application.StartupPath & "\Servers.ini"
    Private strSource As String = Application.StartupPath & "\Source.ini"
    Private srcDomain As String = ""

#End Region

#Region "General"
    'Form Load
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Saved Servers from configuration file
        Dim i As Integer
        Dim Sec() As String
        Sec = INIGetAllSection(strConfig)
        For i = LBound(Sec) To UBound(Sec)
            If Sec(i) = "" Then Exit Sub
            lstServer.Items.Add(Sec(i))
        Next i
        'Load Source from Source File
        ReloadSource()
        'Load "Select Server" Combobox 
        ReloadServer()
    End Sub

    'Form Closing
    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Dispose Loaded Image
        picBOM.Image.Dispose()
        'If Exists, Remove Temp Folder
        If IO.Directory.Exists(Application.StartupPath & "\Temp") = True Then
            My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
    End Sub

#End Region

#Region "Quick Start: Package"

    'Select Package
    Private Sub btnSelectPackage_Click(sender As Object, e As EventArgs) Handles btnSelectPackage.Click
        'Get selection
        If Not ofdSelectPackage.ShowDialog() = DialogResult.OK Then Exit Sub
        'Check Temp Directory Exists
        If IO.Directory.Exists(Application.StartupPath & "\Temp") = True Then
            'If Exists, Clear The Directory
            picBOM.Image.Dispose()
            My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\Temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
            IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
        Else
            'If NOT Exist, Create One
            IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
        End If

        'Unzip the file
        Try
            UnZip(ofdSelectPackage.FileName)
        Catch ex As Exception
            MessageBox.Show(My.Resources.IO_Package_Invalid, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'If exists, Load the Picture
        If IO.File.Exists(Application.StartupPath & "\Temp\logo.png") Then
            picBOM.Image = Image.FromFile(Application.StartupPath & "\Temp\logo.png")
        Else
            picBOM.Image = Image.FromHbitmap(My.Resources.FUS_004.GetHbitmap)
        End If

        'Load the Title
        If Not IO.File.Exists(Application.StartupPath & "\Temp\packname") Then
            MessageBox.Show(My.Resources.IO_Package_Invalid, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtBOM.Text = My.Resources.UI_txtBOM_Default
            btnInfo.Enabled = False
            Exit Sub
        End If
        Dim sr As New IO.StreamReader(Application.StartupPath & "\Temp\packname", System.Text.Encoding.UTF8)
        txtBOM.Text = sr.ReadToEnd
        sr.Close()
        sr.Dispose()

        'Enable Show Package Info Button
        btnInfo.Enabled = True
    End Sub

    'View Package Details
    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        'Create an Intent to pass parameter to PackageWindow
        Dim itnPackage As New Intent
        itnPackage.AddExtra("Path", Application.StartupPath & "\Temp\")
        Dim frmPack As New PackageForm()
        frmPack.PackSource = PackageForm.PackageSource.FormFile
        frmPack.FormIntent = itnPackage
        frmPack.InstallAvaliable = False
        frmPack.ShowDialog()
    End Sub

#End Region

#Region "Quick Start: Server"

    'Reload servers in combobox
    Private Sub ReloadServer()
        cbxServer.Items.Clear()
        For Each item As String In lstServer.Items
            cbxServer.Items.Add(item)
        Next
    End Sub

#End Region

#Region "Quick Start: Install"

    'Hit the Apply button
    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        'Make sure Package, Server, Action are selected
        'If btnInfo.Enabled = False Or cbxServer.SelectedItem = "" Or cbxSource.SelectedItem = "" Then Exit Sub
        'Create an intent
        Dim itnQuickStart As New Intent
        itnQuickStart.AddExtra("IP", INIGet(cbxServer.SelectedItem, "IP", Nothing, strConfig))
        itnQuickStart.AddExtra("Port", INIGet(cbxServer.SelectedItem, "Port", Nothing, strConfig))
        itnQuickStart.AddExtra("User", INIGet(cbxServer.SelectedItem, "User", Nothing, strConfig))
        itnQuickStart.AddExtra("Passwd", INIGet(cbxServer.SelectedItem, "Passwd", Nothing, strConfig))
        'Set up DeployWindow
        Dim frmDeploy As New DeployForm
        frmDeploy.PackageSource = DeployForm.SourceEnum.FromLocal
        frmDeploy.DeployIntent = itnQuickStart
        frmDeploy.ShowDialog()
    End Sub

#End Region

#Region "Boom Source: Misc"

    'Manage Source & Refresh Source List Combobox
    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        SourceForm.ShowDialog()
    End Sub

    'Refresh List
    Private Sub cbxSource_Click(sender As Object, e As EventArgs) Handles cbxSource.Click
        ReloadSource()
    End Sub

#End Region

#Region "Boom Source: Load Categories"

    'Load Source Combobox From Source File
    Private Sub ReloadSource()
        cbxSource.Items.Clear()
        Dim isrc As Integer
        Dim SecSrc() As String
        SecSrc = INIGetAllSection(strSource)
        For isrc = LBound(SecSrc) To UBound(SecSrc)
            If SecSrc(isrc) = "" Then Exit Sub
            cbxSource.Items.Add(SecSrc(isrc))
        Next isrc
    End Sub

    'Load Source Categories
    Private Sub btnLoadSource_Click(sender As Object, e As EventArgs) Handles btnLoadSource.Click
        'If Exists, Remove the temp bom.xml
        If IO.File.Exists(Application.StartupPath & "\Temp\bom.xml") Then
            IO.File.Delete(Application.StartupPath & "\Temp\bom.xml")
        End If
        IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
        'If selected source is empty, abort
        If cbxSource.SelectedItem = "" Then Exit Sub
        'Clear Listboxes
        lstCategory.Items.Clear()
        lstPackage.Items.Clear()
        'Start Fetching Categories
        bgwSource.RunWorkerAsync(cbxSource.SelectedItem)
    End Sub

    'Source Thread
    Private Sub bgwSource_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSource.DoWork
        'Get source domain from source configuration file
        Dim strSourceDomain As String
        strSourceDomain = INIGet(e.Argument, "Domain", Nothing, strSource)
        srcDomain = strSourceDomain
        bgwSource.ReportProgress(1)
        'Err returns 51
        If strSourceDomain = "" Then
            bgwSource.ReportProgress(51)
            Exit Sub
        End If

        'Get bom.xml from source domain
        Try
            Dim wcFile As New Net.WebClient
            wcFile.DownloadFile("http://" & strSourceDomain & "/bom.xml", Application.StartupPath & "\Temp\bom.xml")
            bgwSource.ReportProgress(2)
        Catch ex As Exception
            bgwSource.ReportProgress(52, ex.Message)
            Exit Sub
        End Try

        'Read XML Information
        Dim strCategories As String
        Try
            strCategories = XmlGetCategories(Application.StartupPath & "\Temp\bom.xml")
            If strCategories = Nothing Then
                bgwSource.ReportProgress(50)
            End If
            bgwSource.ReportProgress(3)
        Catch ex As Exception
            bgwSource.ReportProgress(53, ex.Message)
            Exit Sub
        End Try

        'Add to listbox
        Try
            bgwSource.ReportProgress(4, strCategories)
        Catch ex As Exception
            bgwSource.ReportProgress(54, ex.Message)
            Exit Sub
        End Try

        'Done
        bgwSource.ReportProgress(100)
    End Sub

    'Return UI Update
    Private Sub bgwSource_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSource.ProgressChanged
        Select Case e.ProgressPercentage
            'Getting Source Domain
            Case 1
                txtStatus.Text = My.Resources.UI_Source_Get_Domain
            'Domain Not Found
            Case 51
                txtStatus.Text = My.Resources.UI_Source_Domain_Not_Found
            'Connecting to Source
            Case 2
                txtStatus.Text = My.Resources.UI_Source_Connecting
            'Connection Error
            Case 52
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Resolve XML
            Case 3
                txtStatus.Text = My.Resources.UI_Source_Resolving_Configuration
            'Resolve Error
            Case 53
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Getting Categories
            Case 4
                txtStatus.Text = My.Resources.UI_Source_Fetch_Data
                lstCategory.Items.Clear()
                lstCategory.Items.AddRange(e.UserState.Split(","))
                lstCategory.Items.RemoveAt(0)
            'Getting Error
            Case 54
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Invalid Source
            Case 50
                txtStatus.Text = My.Resources.UI_Source_Invalid_Source
            'Done
            Case 100
                txtStatus.Text = My.Resources.UI_Source_Done
        End Select
    End Sub

#End Region

#Region "Boom Source: Load Packages"
    'Load Package from Source
    Private Sub lstCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategory.SelectedIndexChanged
        If lstCategory.SelectedItem = "" Then Exit Sub
        If cbxSource.SelectedItem = "" Then Exit Sub
        bgwPackage.RunWorkerAsync(lstCategory.SelectedItem)
    End Sub

    'Package Thread
    Private Sub bgwPackage_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwPackage.DoWork
        'Fetch Packages
        Dim strPackages As String = ""
        Try
            strPackages = XmlGetPackages(Application.StartupPath & "\Temp\bom.xml", e.Argument)
            bgwPackage.ReportProgress(1)
        Catch ex As Exception
            bgwPackage.ReportProgress(51, ex.Message)
            Exit Sub
        End Try

        'Add to listbox
        Try
            bgwPackage.ReportProgress(2, strPackages)
        Catch ex As Exception
            bgwPackage.ReportProgress(52, ex.Message)
            Exit Sub
        End Try

        'Done
        bgwPackage.ReportProgress(100)
    End Sub

    'Apply UI Changes
    Private Sub bgwPackage_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwPackage.ProgressChanged
        Select Case e.ProgressPercentage
            'Get package from xml
            Case 1
                txtStatus.Text = My.Resources.UI_Source_Resolving_Configuration
            'Get package error
            Case 51
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Add Packages to listbox
            Case 2
                txtStatus.Text = My.Resources.UI_Source_Fetch_Data
                lstPackage.Items.Clear()
                lstPackage.Items.AddRange(e.UserState.Split(","))
                lstPackage.Items.RemoveAt(lstPackage.Items.Count - 1)
            'Add Error
            Case 52
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Done
            Case 100
                txtStatus.Text = My.Resources.UI_Source_Done
        End Select
    End Sub

#End Region

#Region "Boom Source: Load Package Details"
    'Double Click to Show Package Details
    Private Sub lstPackage_DoubleClick(sender As Object, e As EventArgs) Handles lstPackage.DoubleClick
        'Make Sure At Least One Item is selected
        If lstPackage.SelectedItem = "" Then Exit Sub
        bgwDetail.RunWorkerAsync(lstPackage.SelectedItem)
    End Sub

    'Load Thread
    Private Sub bgwDetail_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDetail.DoWork
        'Get Package Detail From XML File
        Dim pkgDetail As BoomPackage
        Try
            pkgDetail = XmlGetDetail(srcDomain, e.Argument)
            bgwDetail.ReportProgress(1)
        Catch ex As Exception
            bgwDetail.ReportProgress(51, ex.Message)
            Exit Sub
        End Try

        'Show Package Detail Form
        Try
            Dim itnDeatail As New Intent
            itnDeatail.AddExtra("Package", pkgDetail)
            Dim strServers As String = ""
            For Each srv As String In lstServer.Items
                strServers &= srv
                strServers &= ","
            Next
            itnDeatail.AddExtra("ServerList", strServers)
            Dim frmPackage As New PackageForm
            frmPackage.InstallAvaliable = True
            frmPackage.PackSource = PackageForm.PackageSource.FromINet
            frmPackage.FormIntent = itnDeatail
            frmPackage.ShowDialog()
            bgwDetail.ReportProgress(2)
        Catch ex As Exception
            bgwDetail.ReportProgress(52, ex.Message)
            Exit Sub
        End Try

        'Done
        bgwDetail.ReportProgress(100)
    End Sub

    'Apply UI Changes
    Private Sub bgwDetail_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDetail.ProgressChanged
        Select Case e.ProgressPercentage
            'Get Detail
            Case 1
                txtStatus.Text = My.Resources.UI_Source_Fetch_Data
            'Get Detail Failed
            Case 51
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Prepare Detail Form
            Case 2
                txtStatus.Text = My.Resources.UI_Source_Prepare_Detail
            'Error
            Case 52
                txtStatus.Text = My.Resources.UI_Source_Error & e.UserState
            'Done
            Case 100
                txtStatus.Text = My.Resources.UI_Source_Done
        End Select
    End Sub
#End Region

#Region "My Servers: Add Server"

    'Show Password if box is checked
    Private Sub ckbPasswd_CheckedChanged(sender As Object, e As EventArgs) Handles ckbPasswd.CheckedChanged
        If ckbPasswd.Checked = False Then
            txtPasswd.PasswordChar = "•"
        Else
            txtPasswd.PasswordChar = ""
        End If
    End Sub

    'Add Server from input
    Private Sub btnAddServer_Click(sender As Object, e As EventArgs) Handles btnAddServer.Click
        'Make sure every blank is filled
        If txtName.Text = "" Or txtIP.Text = "" Or txtPort.Text = "" Or txtUser.Text = "" Or txtPasswd.Text = "" Then Exit Sub
        INISet(txtName.Text, "IP", txtIP.Text, strConfig)
        INISet(txtName.Text, "Port", txtPort.Text, strConfig)
        INISet(txtName.Text, "User", txtUser.Text, strConfig)
        INISet(txtName.Text, "Passwd", txtPasswd.Text, strConfig)
        lstServer.Items.Add(txtName.Text)

        'Reload Quick Start Server List
        ReloadServer()
    End Sub

    'Import from SVR file
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If Not ofdImport.ShowDialog() = DialogResult.OK Then Exit Sub
        Dim strFile As String = ofdImport.FileName
        txtIP.Text = INIGet("Server", "IP", My.Resources.UI_Invalid_Server_From_Config, strFile)
        txtPort.Text = INIGet("Server", "Port", My.Resources.UI_Invalid_Server_From_Config, strFile)
        txtUser.Text = INIGet("Server", "User", My.Resources.UI_Invalid_Server_From_Config, strFile)
        txtPasswd.Text = INIGet("Server", "Passwd", My.Resources.UI_Invalid_Server_From_Config, strFile)
    End Sub

#End Region

#Region "My Server: Misc"

    'Remove Server
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'You must select one to remove
        If lstServer.SelectedItem = "" Then Exit Sub
        'Confirm
        Dim strServerToRemove As String = lstServer.SelectedItem
        If MessageBox.Show(My.Resources.UI_Confirm_Remove_server & strServerToRemove & "' ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            lstServer.Items.Remove(strServerToRemove)
            INIRemoveSection(strServerToRemove, strConfig)
            'Reload combobox
            ReloadServer()
        End If
    End Sub

    'Load server info when selected from listbox
    Private Sub lstServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstServer.SelectedIndexChanged
        'You must select one from list to view detail
        If lstServer.SelectedItem = "" Then Exit Sub
        Dim strSelected As String = lstServer.SelectedItem
        txtName.Text = strSelected
        txtIP.Text = INIGet(strSelected, "IP", My.Resources.UI_Invalid_Server_From_Config, strConfig)
        txtPort.Text = INIGet(strSelected, "Port", My.Resources.UI_Invalid_Server_From_Config, strConfig)
        txtUser.Text = INIGet(strSelected, "User", My.Resources.UI_Invalid_Server_From_Config, strConfig)
        txtPasswd.Text = INIGet(strSelected, "Passwd", My.Resources.UI_Invalid_Server_From_Config, strConfig)
    End Sub


#End Region

#Region "About: Links"

    'View on Github
    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Process.Start("https://github.com/CYRO4S/BoomVM")
    End Sub

    'Twitter
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Process.Start("https://twitter.com/CYRO4S")
    End Sub

    'Github
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Process.Start("https://github.com/CYRO4S")
    End Sub

    'Website
    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Process.Start("https://www.boomvm.com")
    End Sub

    'TG Group
    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Process.Start("https://telegram.me/boomvm")
    End Sub

    'TG Channel
    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Process.Start("https://telegram.me/boomvm_channel")
    End Sub

    'SSH.NET
    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click
        Process.Start("https://github.com/sshnet/SSH.NET")
    End Sub

    'dotNetZip
    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click
        Process.Start("https://github.com/eropple/dotnetzip")
    End Sub


#End Region

End Class
