<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.picBoomVM = New System.Windows.Forms.PictureBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabStart = New System.Windows.Forms.TabPage()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxServer = New System.Windows.Forms.ComboBox()
        Me.btnSelectPackage = New System.Windows.Forms.Button()
        Me.txtBOM = New System.Windows.Forms.Label()
        Me.picBOM = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.tabSource = New System.Windows.Forms.TabPage()
        Me.lstPackage = New System.Windows.Forms.ListBox()
        Me.lstCategory = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.btnLoadSource = New System.Windows.Forms.Button()
        Me.btnManage = New System.Windows.Forms.Button()
        Me.cbxSource = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabServer = New System.Windows.Forms.TabPage()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnAddServer = New System.Windows.Forms.Button()
        Me.ckbPasswd = New System.Windows.Forms.CheckBox()
        Me.txtPasswd = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstServer = New System.Windows.Forms.ListBox()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ofdSelectPackage = New System.Windows.Forms.OpenFileDialog()
        Me.ofdImport = New System.Windows.Forms.OpenFileDialog()
        Me.bgwSource = New System.ComponentModel.BackgroundWorker()
        Me.bgwPackage = New System.ComponentModel.BackgroundWorker()
        Me.imgPackage = New System.Windows.Forms.ImageList(Me.components)
        Me.bgwDetail = New System.ComponentModel.BackgroundWorker()
        CType(Me.picBoomVM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabStart.SuspendLayout()
        CType(Me.picBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSource.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tabServer.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBoomVM
        '
        resources.ApplyResources(Me.picBoomVM, "picBoomVM")
        Me.picBoomVM.Image = Global.BoomVM_Veldin.My.Resources.Resources.BoomVM_004
        Me.picBoomVM.Name = "picBoomVM"
        Me.picBoomVM.TabStop = False
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Controls.Add(Me.tabStart)
        Me.tabMain.Controls.Add(Me.tabSource)
        Me.tabMain.Controls.Add(Me.tabServer)
        Me.tabMain.Controls.Add(Me.tabAbout)
        Me.tabMain.HotTrack = True
        Me.tabMain.Multiline = True
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        '
        'tabStart
        '
        resources.ApplyResources(Me.tabStart, "tabStart")
        Me.tabStart.Controls.Add(Me.btnInfo)
        Me.tabStart.Controls.Add(Me.Label6)
        Me.tabStart.Controls.Add(Me.cbxServer)
        Me.tabStart.Controls.Add(Me.btnSelectPackage)
        Me.tabStart.Controls.Add(Me.txtBOM)
        Me.tabStart.Controls.Add(Me.picBOM)
        Me.tabStart.Controls.Add(Me.Label4)
        Me.tabStart.Controls.Add(Me.Label3)
        Me.tabStart.Controls.Add(Me.btnApply)
        Me.tabStart.Name = "tabStart"
        Me.tabStart.UseVisualStyleBackColor = True
        '
        'btnInfo
        '
        resources.ApplyResources(Me.btnInfo, "btnInfo")
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'cbxServer
        '
        resources.ApplyResources(Me.cbxServer, "cbxServer")
        Me.cbxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxServer.FormattingEnabled = True
        Me.cbxServer.Name = "cbxServer"
        '
        'btnSelectPackage
        '
        resources.ApplyResources(Me.btnSelectPackage, "btnSelectPackage")
        Me.btnSelectPackage.Name = "btnSelectPackage"
        Me.btnSelectPackage.UseVisualStyleBackColor = True
        '
        'txtBOM
        '
        resources.ApplyResources(Me.txtBOM, "txtBOM")
        Me.txtBOM.Name = "txtBOM"
        '
        'picBOM
        '
        resources.ApplyResources(Me.picBOM, "picBOM")
        Me.picBOM.Image = Global.BoomVM_Veldin.My.Resources.Resources.FUS_004
        Me.picBOM.Name = "picBOM"
        Me.picBOM.TabStop = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Name = "Label3"
        '
        'btnApply
        '
        resources.ApplyResources(Me.btnApply, "btnApply")
        Me.btnApply.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnApply.Name = "btnApply"
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'tabSource
        '
        resources.ApplyResources(Me.tabSource, "tabSource")
        Me.tabSource.Controls.Add(Me.lstPackage)
        Me.tabSource.Controls.Add(Me.lstCategory)
        Me.tabSource.Controls.Add(Me.Panel1)
        Me.tabSource.Name = "tabSource"
        Me.tabSource.UseVisualStyleBackColor = True
        '
        'lstPackage
        '
        resources.ApplyResources(Me.lstPackage, "lstPackage")
        Me.lstPackage.BackColor = System.Drawing.Color.LightBlue
        Me.lstPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstPackage.FormattingEnabled = True
        Me.lstPackage.Name = "lstPackage"
        '
        'lstCategory
        '
        resources.ApplyResources(Me.lstCategory, "lstCategory")
        Me.lstCategory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lstCategory.FormattingEnabled = True
        Me.lstCategory.Name = "lstCategory"
        Me.lstCategory.Sorted = True
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.btnLoadSource)
        Me.Panel1.Controls.Add(Me.btnManage)
        Me.Panel1.Controls.Add(Me.cbxSource)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Name = "Panel1"
        '
        'txtStatus
        '
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        '
        'btnLoadSource
        '
        resources.ApplyResources(Me.btnLoadSource, "btnLoadSource")
        Me.btnLoadSource.Name = "btnLoadSource"
        Me.btnLoadSource.UseVisualStyleBackColor = True
        '
        'btnManage
        '
        resources.ApplyResources(Me.btnManage, "btnManage")
        Me.btnManage.Name = "btnManage"
        Me.btnManage.UseVisualStyleBackColor = True
        '
        'cbxSource
        '
        resources.ApplyResources(Me.cbxSource, "cbxSource")
        Me.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSource.FormattingEnabled = True
        Me.cbxSource.Name = "cbxSource"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'tabServer
        '
        resources.ApplyResources(Me.tabServer, "tabServer")
        Me.tabServer.Controls.Add(Me.btnRemove)
        Me.tabServer.Controls.Add(Me.GroupBox1)
        Me.tabServer.Controls.Add(Me.lstServer)
        Me.tabServer.Name = "tabServer"
        Me.tabServer.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.BackColor = System.Drawing.Color.Red
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.btnImport)
        Me.GroupBox1.Controls.Add(Me.btnAddServer)
        Me.GroupBox1.Controls.Add(Me.ckbPasswd)
        Me.GroupBox1.Controls.Add(Me.txtPasswd)
        Me.GroupBox1.Controls.Add(Me.txtUser)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtIP)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'btnImport
        '
        resources.ApplyResources(Me.btnImport, "btnImport")
        Me.btnImport.Name = "btnImport"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnAddServer
        '
        resources.ApplyResources(Me.btnAddServer, "btnAddServer")
        Me.btnAddServer.Name = "btnAddServer"
        Me.btnAddServer.UseVisualStyleBackColor = True
        '
        'ckbPasswd
        '
        resources.ApplyResources(Me.ckbPasswd, "ckbPasswd")
        Me.ckbPasswd.Name = "ckbPasswd"
        Me.ckbPasswd.UseVisualStyleBackColor = True
        '
        'txtPasswd
        '
        resources.ApplyResources(Me.txtPasswd, "txtPasswd")
        Me.txtPasswd.Name = "txtPasswd"
        '
        'txtUser
        '
        resources.ApplyResources(Me.txtUser, "txtUser")
        Me.txtUser.Name = "txtUser"
        '
        'txtPort
        '
        resources.ApplyResources(Me.txtPort, "txtPort")
        Me.txtPort.Name = "txtPort"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'txtIP
        '
        resources.ApplyResources(Me.txtIP, "txtIP")
        Me.txtIP.Name = "txtIP"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'lstServer
        '
        resources.ApplyResources(Me.lstServer, "lstServer")
        Me.lstServer.BackColor = System.Drawing.Color.White
        Me.lstServer.FormattingEnabled = True
        Me.lstServer.Name = "lstServer"
        '
        'tabAbout
        '
        resources.ApplyResources(Me.tabAbout, "tabAbout")
        Me.tabAbout.Controls.Add(Me.Label26)
        Me.tabAbout.Controls.Add(Me.Label24)
        Me.tabAbout.Controls.Add(Me.Label23)
        Me.tabAbout.Controls.Add(Me.Label22)
        Me.tabAbout.Controls.Add(Me.Label21)
        Me.tabAbout.Controls.Add(Me.Label28)
        Me.tabAbout.Controls.Add(Me.Label17)
        Me.tabAbout.Controls.Add(Me.Label27)
        Me.tabAbout.Controls.Add(Me.Label25)
        Me.tabAbout.Controls.Add(Me.Label20)
        Me.tabAbout.Controls.Add(Me.Label19)
        Me.tabAbout.Controls.Add(Me.Label30)
        Me.tabAbout.Controls.Add(Me.Label29)
        Me.tabAbout.Controls.Add(Me.Label18)
        Me.tabAbout.Controls.Add(Me.Label16)
        Me.tabAbout.Controls.Add(Me.Label15)
        Me.tabAbout.Controls.Add(Me.Label14)
        Me.tabAbout.Controls.Add(Me.Label13)
        Me.tabAbout.Controls.Add(Me.Label12)
        Me.tabAbout.Controls.Add(Me.PictureBox3)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.UseVisualStyleBackColor = True
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label27.Name = "Label27"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label25.Name = "Label25"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label20.Name = "Label20"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label19.Name = "Label19"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label30.Name = "Label30"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label29.Name = "Label29"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label18.Name = "Label18"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'PictureBox3
        '
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Image = Global.BoomVM_Veldin.My.Resources.Resources.BoomVM_004
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ofdSelectPackage
        '
        Me.ofdSelectPackage.FileName = "My Package.bom"
        resources.ApplyResources(Me.ofdSelectPackage, "ofdSelectPackage")
        '
        'ofdImport
        '
        Me.ofdImport.FileName = "My Server.svr"
        resources.ApplyResources(Me.ofdImport, "ofdImport")
        '
        'bgwSource
        '
        Me.bgwSource.WorkerReportsProgress = True
        '
        'bgwPackage
        '
        Me.bgwPackage.WorkerReportsProgress = True
        '
        'imgPackage
        '
        Me.imgPackage.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.imgPackage, "imgPackage")
        Me.imgPackage.TransparentColor = System.Drawing.Color.Transparent
        '
        'bgwDetail
        '
        Me.bgwDetail.WorkerReportsProgress = True
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.picBoomVM)
        Me.Name = "MainForm"
        CType(Me.picBoomVM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabStart.ResumeLayout(False)
        Me.tabStart.PerformLayout()
        CType(Me.picBOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSource.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabServer.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabAbout.ResumeLayout(False)
        Me.tabAbout.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picBoomVM As PictureBox
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabStart As TabPage
    Friend WithEvents tabSource As TabPage
    Friend WithEvents tabServer As TabPage
    Friend WithEvents tabAbout As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxServer As ComboBox
    Friend WithEvents btnSelectPackage As Button
    Friend WithEvents txtBOM As Label
    Friend WithEvents picBOM As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnManage As Button
    Friend WithEvents cbxSource As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents lstServer As ListBox
    Friend WithEvents ofdSelectPackage As OpenFileDialog
    Friend WithEvents ofdImport As OpenFileDialog
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnInfo As Button
    Friend WithEvents lstCategory As ListBox
    Friend WithEvents bgwSource As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwPackage As System.ComponentModel.BackgroundWorker
    Friend WithEvents imgPackage As ImageList
    Friend WithEvents btnLoadSource As Button
    Friend WithEvents lstPackage As ListBox
    Friend WithEvents btnRemove As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnImport As Button
    Friend WithEvents btnAddServer As Button
    Friend WithEvents ckbPasswd As CheckBox
    Friend WithEvents txtPasswd As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtIP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents bgwDetail As System.ComponentModel.BackgroundWorker
End Class
