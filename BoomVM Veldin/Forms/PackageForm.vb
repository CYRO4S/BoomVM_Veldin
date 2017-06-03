Imports System.ComponentModel

Public Class PackageForm

    'Global Vars
    Private itnPackage As Intent
    Private intSource As PackageSource
    Private bolInstall As Boolean
    Private pkgDetail As BoomPackage
    Public Enum PackageSource
        FormFile = 0
        FromINet = 1
    End Enum

    'Get & Set Intent from owner window
    Public Property FormIntent As Intent
        Set(value As Intent)
            itnPackage = value
        End Set
        Get
            Return itnPackage
        End Get
    End Property

    'Get & Set Package Source is from local file or Internet
    Public Property PackSource As PackageSource
        Get
            Return intSource
        End Get
        Set(value As PackageSource)
            intSource = value
        End Set
    End Property

    'Get & Set whether "Install" is shown or not
    Public Property InstallAvaliable As Boolean
        Set(value As Boolean)
            bolInstall = value
        End Set
        Get
            Return bolInstall
        End Get
    End Property

    'Load Package Detail When Loaded
    Private Sub PackageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Install button
        btnInstall.Visible = Me.InstallAvaliable
        cbxList.Visible = Me.InstallAvaliable
        Label2.Visible = Me.InstallAvaliable
        Select Case Me.PackSource
            'Load Package Info From Local File
            Case PackageSource.FormFile
                'Get Local File Path
                Dim Path As String = Me.FormIntent.GetExtra("Path")
                'If exists, load the logo
                If IO.File.Exists(Path & "logo.png") Then
                    picIcon.Image = Image.FromFile(Path & "logo.png")
                Else
                    picIcon.Image = Image.FromHbitmap(My.Resources.FUS_004.GetHbitmap)
                End If
                'Load Packname
                Dim srPackname As New IO.StreamReader(Path & "packname", System.Text.Encoding.UTF8)
                lblPackname.Text = srPackname.ReadToEnd
                Me.Text = lblPackname.Text
                srPackname.Close()
                srPackname.Dispose()
                'Load Author
                Dim srAuthor As New IO.StreamReader(Path & "author", System.Text.Encoding.UTF8)
                lblAuthor.Text = srAuthor.ReadToEnd
                srAuthor.Close()
                srAuthor.Dispose()
                'Load Intro
                Dim srIntro As New IO.StreamReader(Path & "intro", System.Text.Encoding.UTF8)
                txtIntro.Text = srIntro.ReadToEnd
                srIntro.Close()
                srIntro.Dispose()
            Case PackageSource.FromINet
                pkgDetail = Me.FormIntent.GetExtra("Package")
                'Load Server List
                Dim strServers As String = Me.FormIntent.GetExtra("ServerList")
                cbxList.Items.AddRange(strServers.Split(","))
                cbxList.Items.RemoveAt(cbxList.Items.Count - 1)
                'Load Name
                lblPackname.Text = pkgDetail.Name
                Me.Text = pkgDetail.Name
                'Load Author
                lblAuthor.Text = pkgDetail.Author
                'Load Intro
                Dim wcFile As New Net.WebClient
                Try
                    wcFile.DownloadFile(pkgDetail.Intro, Application.StartupPath & "\Temp\intro")
                    Dim srIntro As New IO.StreamReader(Application.StartupPath & "\Temp\intro", System.Text.Encoding.UTF8)
                    txtIntro.Text = srIntro.ReadToEnd
                    srIntro.Close()
                    srIntro.Dispose()
                Catch ex As Exception
                    MessageBox.Show(My.Resources.UI_Package_Detail_Load_Error & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Exit Sub
                End Try
                'Load Icon
                Try
                    wcFile.DownloadFile(pkgDetail.Icon, Application.StartupPath & "\Temp\icon.png")
                    picIcon.Image = Image.FromFile(Application.StartupPath & "\Temp\icon.png")
                Catch ex As Exception
                    MessageBox.Show(My.Resources.UI_Package_Detail_Load_Error & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Exit Sub
                End Try
        End Select
    End Sub

    'Do some cleaning when closing this window
    Private Sub PackageForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            picIcon.Image.Dispose()
        Catch ex As Exception
        End Try
        txtIntro.Clear()
        If IO.File.Exists(Application.StartupPath & "\Temp\icon.png") Then
            IO.File.Delete(Application.StartupPath & "\Temp\icon.png")
        End If
        If IO.File.Exists(Application.StartupPath & "\Temp\intro") Then
            IO.File.Delete(Application.StartupPath & "\Temp\intro")
        End If
    End Sub

    'Commence Deployment
    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        Dim frmDeploy As New DeployForm
        frmDeploy.PackageSource = DeployForm.SourceEnum.FromBoomSource
        Dim itnDeploy As New Intent
        itnDeploy.AddExtra("Server", cbxList.SelectedItem)
        itnDeploy.AddExtra("Package", pkgDetail)
        frmDeploy.DeployIntent = itnDeploy
        frmDeploy.ShowDialog()
    End Sub
End Class
